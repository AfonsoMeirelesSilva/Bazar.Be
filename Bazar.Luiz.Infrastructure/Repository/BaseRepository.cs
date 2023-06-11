using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar.Luiz.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IDbContext _dapper;

        public BaseRepository(IDbContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM {typeof(T).Name}";
            return await _dapper.GetAllAsync<T>(query);
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync()
        {
            var query = $"SELECT * FROM {typeof(T).Name} where Ativo=1";
            return await _dapper.GetAllAsync<T>(query);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dapper.GetAsync<T>(query, parameters);
        }

        public async Task<int> InsertAsync(T entity)
        {
            var query = $"INSERT INTO {typeof(T).Name} ({GetColumns()}) VALUES ({GetColumnsWithValue()}); SELECT SCOPE_IDENTITY();";
            return await _dapper.InsertAsync<int>(query, entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var query = $"UPDATE {typeof(T).Name} SET {GetColumnsWithValueToUpdate()} WHERE Id = @Id";
            return await _dapper.UpdateAsync(query, entity) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dapper.DeleteAsync(query, parameters) > 0;
        }

        private string GetColumns()
        {
            var columns = typeof(T).GetProperties().Select(p => p.Name);
            return string.Join(",", columns);
        }

        private string GetColumnsWithValue()
        {
            var columns = typeof(T).GetProperties().Select(p => $"@{p.Name}");
            return string.Join(",", columns);
        }

        private string GetColumnsWithValueToUpdate()
        {
            var columns = typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"{p.Name} = @{p.Name}");
            return string.Join(",", columns);
        }
    }
}
