using HouseholdExpensesTrackerServer.Domain.Identity;
using HouseholdExpensesTrackerServer.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Infrastructure.Context
{
    public class HouseholdDbContext: DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CredentialType> CredentialTypes { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public HouseholdDbContext(DbContextOptions<HouseholdDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CredentialTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CredentialConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        }
    }
}
