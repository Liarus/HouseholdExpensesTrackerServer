using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<TModel, UIdentifier> : IRepository<TModel, UIdentifier>
        where TModel : class, IEntity<UIdentifier>
    {
        private readonly IDbContext _context;
        private DbSet<TModel> _dbSet;

        public EntityFrameworkRepository(IDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        public void Add(TModel entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TModel entity, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbSet.AddAsync(entity, cancellationToken); 
        }

        public void Delete(TModel entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteById(UIdentifier id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
        }

        public async Task DeleteByIdAsync(UIdentifier id, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await this.GetByIdAsync(id, cancellationToken);
            this.Delete(entity);
        }

        public TModel Find(Expression<Func<TModel, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public ICollection<TModel> FindAll(Expression<Func<TModel, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task<ICollection<TModel>> FindAllAsync(Expression<Func<TModel, bool>> predicate, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TModel> FindAsync(Expression<Func<TModel, bool>> predicate, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbSet.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public ICollection<TModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<ICollection<TModel>> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public TModel GetById(UIdentifier id)
        {
            return _dbSet.Find();
        }

        public async Task<TModel> GetByIdAsync(UIdentifier id, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
