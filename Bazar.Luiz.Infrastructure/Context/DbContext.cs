using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Bazar.Luiz.Infrastructure.Context
{
    public class DbContext : IDbContext
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; private set; }

        public DbContext(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public async Task<T> GetAsync<T>(string query, object parameters = null)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(query, parameters);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string query, object parameters = null)
        {
            return await Connection.QueryAsync<T>(query, parameters);
        }

        public async Task<int> ExecuteAsync(string query, object parameters = null)
        {
            return await Connection.ExecuteAsync(query, parameters);
        }

        public async Task<T> InsertAsync<T>(string query, object parameters = null)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(query, parameters);
        }

        public async Task<int> UpdateAsync(string query, object parameters = null)
        {
            return await Connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> DeleteAsync(string query, object parameters = null)
        {
            return await Connection.ExecuteAsync(query, parameters);
        }

        public void Dispose()
        {
            Connection.Dispose();
        }

        public void BeginTransaction()
        {
           Transaction =  Connection?.BeginTransaction();
        }

        public void CommitTransaction()
        {
           Transaction?.Commit();
        }
    }
}
