﻿using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Repository;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class RoleRepository : EntityFrameworkRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(IDbContext context) : base(context)
        {

        }

        public override async Task<Role> GetByIdAsync(int id, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<Role> query = _dbSet;
            var includes = new Includes<Role>(e =>
            {
                return e.Include(b => b.RolePermissions);
            });
            query = includes.Expression(query);

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Role>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var includes = new Includes<Role>(query =>
            {
                return query.Include(b => b.RolePermissions);
            });
            var result = this.QueryDb(null, null, includes.Expression);
            return await result.ToListAsync(); ;
        }

        public override async Task<Role> FindAsync(Expression<Func<Role, bool>> predicate, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var includes = new Includes<Role>(query =>
            {
                return query.Include(b => b.RolePermissions);
            });
            var result = this.QueryDb(predicate, null, includes.Expression);
            return await result.FirstOrDefaultAsync();
        }

        public override async Task<ICollection<Role>> FindAllAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            var includes = new Includes<Role>(query =>
            {
                return query.Include(b => b.RolePermissions);
            });
            var result = this.QueryDb(predicate, null, includes.Expression);
            return await result.ToListAsync();
        }
    }
}
