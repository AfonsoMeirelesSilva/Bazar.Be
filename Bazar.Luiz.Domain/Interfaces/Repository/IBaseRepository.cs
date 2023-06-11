using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar.Luiz.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllActiveAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
