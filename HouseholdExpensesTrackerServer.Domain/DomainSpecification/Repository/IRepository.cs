using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.DomainSpecification.Repository
{
    public interface IRepository<T, U>
    {
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        Task<ICollection<T>> GetAllAsync();

        Task<T> GetByIdAsync(U id);

        Task<int> SaveChangesAsync();
    }
}
