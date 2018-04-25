using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using HouseholdExpensesTrackerServer.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System.Threading;

namespace HouseholdExpensesTrackerServer.Infrastructure.Context
{
    public class HouseholdDbContext: DbContext, IDbContext
    {
        protected const string CONCURRENCY_PROPERTY_NAME = "RowVersion";

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

        public HouseholdDbContext(DbContextOptions<HouseholdDbContext> options) : base(options)
        {
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
            this.ManageTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected virtual string GetCurrentUser()
        {
            return "Me";
        }

        protected virtual void ManageTimestamps()
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
                }
                else if (entity.State == EntityState.Modified)
                {
                    ((IAuditableEntity)entity.Entity).UpdateAuditable(DateTime.UtcNow, currentUsername);
                }
            }
        }
    }
}
