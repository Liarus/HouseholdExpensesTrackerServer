using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository
{
    public interface IRepository<TModel, UIdentifier>
    {
        Task<ICollection<TModel>> FindAllAsync(Expression<Func<UIdentifier, bool>> predicate);

        Task<TModel> FindAsync(Expression<Func<UIdentifier, bool>> predicate);

        Task<ICollection<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(UIdentifier id);

        Task<int> SaveChangesAsync();

        void Add(TModel entity);

        void Delete(TModel entity);

        void DeleteById(UIdentifier id);
    }
}
