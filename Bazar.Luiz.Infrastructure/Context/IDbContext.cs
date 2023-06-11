using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Luiz.Infrastructure.Context
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void CommitTransaction();

        Task<T> GetAsync<T>(string query, object parameters = null);
        Task<IEnumerable<T>> GetAllAsync<T>(string query, object parameters = null);
        Task<int> ExecuteAsync(string query, object parameters = null);
        Task<T> InsertAsync<T>(string query, object parameters = null);
        Task<int> UpdateAsync(string query, object parameters = null);
        Task<int> DeleteAsync(string query, object parameters = null);
    }
}
