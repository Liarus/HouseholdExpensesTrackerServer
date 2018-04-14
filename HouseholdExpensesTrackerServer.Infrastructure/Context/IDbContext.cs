using HouseholdExpensesTrackerServer.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Infrastructure.Context
{
    public interface IDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<CredentialType> CredentialTypes { get; set; }

        DbSet<Credential> Credentials { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<UserRole> UserRoles { get; set; }

        DbSet<Permission> Permissions { get; set; }

        DbSet<RolePermission> RolePermissions { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
