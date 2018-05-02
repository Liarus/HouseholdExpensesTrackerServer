using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using HouseholdExpensesTrackerServer.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System.Threading;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;

namespace HouseholdExpensesTrackerServer.Infrastructure.Context
{
    public class HouseholdDbContext: DbContext, IDbContext
    {
        private readonly List<IAuditableEntity> _added = new List<IAuditableEntity>();

        private readonly ConcurrentDictionary<string, List<int>> _insertedIds = new ConcurrentDictionary<string, List<int>>();

        private readonly IEventDispatcherAsync _eventDispatcher;

        protected const string CONCURRENCY_PROPERTY_NAME = "Version";

        public DbSet<User> Users { get; set; }

        public DbSet<CredentialType> CredentialTypes { get; set; }

        public DbSet<Credential> Credentials { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        public DbSet<SavingType> SavingTypes { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Saving> Savings { get; set; }

        public DbSet<Household> Households { get; set; }

        public HouseholdDbContext(DbContextOptions<HouseholdDbContext> options, IEventDispatcherAsync eventDispatcher) : base(options)
        {
            _eventDispatcher = eventDispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CredentialTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SavingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CredentialConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new HouseholdConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new SavingConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var events = this.GatherAllUncommitedEvents();
            this.ManageEntities();
            var result =  await base.SaveChangesAsync(cancellationToken);
            this.FillInsertedIds();
            await this.DispatchEvents(events);
            return result;
        }

        public IReadOnlyCollection<int> GetAllInsertedIds(string entityType)
        {
            var ids = new List<int>();
            _insertedIds.TryGetValue(entityType, out ids);
            return ids;
        }

        protected virtual string GetCurrentUser()
        {
            return "Me";
        }

        protected virtual void ManageEntities()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is IAuditableEntity);
            var currentUsername = this.GetCurrentUser();

            foreach (var entity in entities)
            {
                if (entity.State != EntityState.Added)
                {
                    //for concurrency check, since all entities were detached
                    entity.Property(CONCURRENCY_PROPERTY_NAME).OriginalValue = entity.Property(CONCURRENCY_PROPERTY_NAME).CurrentValue;
                }

                if (entity.State == EntityState.Added)
                {
                    ((IAuditableEntity)entity.Entity).CreateAuditable(DateTime.UtcNow, currentUsername);
                    _added.Add((IAuditableEntity)entity.Entity);
                }
                else if (entity.State == EntityState.Modified)
                {
                    ((IAuditableEntity)entity.Entity).UpdateAuditable(DateTime.UtcNow, currentUsername);
                }
            }
        }

        protected virtual void FillInsertedIds()
        {
            foreach(var entity in _added)
            {
                _insertedIds.AddOrUpdate(entity.GetType().Name, new List<int> { (int)GetPropValue(entity, "Id") }, (key, value) =>
                {
                    value.Add((int)GetPropValue(entity, "Id"));
                    return value;
                });
            }
            _added.Clear();
        }

        protected virtual IReadOnlyCollection<IEvent[]> GatherAllUncommitedEvents()
        {
            var domainEventAggregates = ChangeTracker.Entries<IAggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

            var events = new List<IEvent[]>();

            foreach (var aggregate in domainEventAggregates)
            {
                events.Add(aggregate.FlushUncommitedEvents());
            }

            return events;
        }

        protected virtual async Task DispatchEvents(IEnumerable<IEvent[]> events)
        {
            if (events.Count() == 0)
            {
                return;
            }

            var tasks = new List<Task>();
            foreach (var group in events)
            {
                foreach(var @event in group)
                {
                    tasks.Add(_eventDispatcher.PublishAsync(@event));
                }
            }
            await Task.WhenAll(tasks);
        }

        protected static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
