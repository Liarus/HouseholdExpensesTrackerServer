using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
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

        DbSet<ExpenseType> ExpenseTypes { get; set; }

        DbSet<SavingType> SavingTypes { get; set; }

        DbSet<Expense> Expenses { get; set; }

        DbSet<Saving> Savings { get; set; }

        DbSet<Household> Households { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
