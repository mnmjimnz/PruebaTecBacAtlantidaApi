using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;
using bco.atlantidad.estadocuenta.api.Core.DTO;

namespace bco.atlantidad.estadocuenta.api.Infraestructura.Data
{
    public class DapperContext : IDapperContext
    {
        private readonly IDbConnection _dbConnection;
        public DapperContext(IOptions<ConnectionString> connectionString)
        {
            _dbConnection = new SqlConnection(connectionString.Value.Connection);
        }

        public async Task<List<T>> GetAll<T>(string query)
        {
            try
            {
                _dbConnection?.Open();
                var data = await _dbConnection.QueryAsync<T>(query);
                return data.ToList();
            }
            catch (Exception)
            {
                return new List<T>();
            }
            finally
            {
                _dbConnection?.Close();
            }
        }
        public async Task<T?> GetById<T>(int id, string query)
        {
            try
            {
                _dbConnection?.Open();
                var customer = await _dbConnection.QueryAsync<T>(query, id);
                return customer.FirstOrDefault();
            }
            catch (Exception)
            {
                return default;
            }
            finally
            {
                _dbConnection?.Close();
            }
        }
        public async Task<List<T?>> GetListById<T>(int id, string query)
        {
            try
            {
                _dbConnection?.Open();
                var customer = await _dbConnection.QueryAsync<T>(query, id);
                return customer.ToList();
            }
            catch (Exception)
            {
                return default;
            }
            finally
            {
                _dbConnection?.Close();
            }
        }
        public async Task<List<T?>> GetPersonalize<T>(string query)
        {
            try
            {
                _dbConnection?.Open();
                var customer = await _dbConnection.QueryAsync<T>(query);
                return customer.ToList();
            }
            catch (Exception)
            {
                return default;
            }
            finally
            {
                _dbConnection?.Close();
            }
        }

        public async Task<T> Create<T>(T _dto, string query)
        {
            try
            {
                _dbConnection?.Open();
                dynamic r = await _dbConnection.ExecuteScalarAsync<dynamic>(query, _dto);
                return r;
            }
            catch (Exception)
            {
                return default;
            }
            finally
            {
                _dbConnection?.Close();
            }
        }
        public async Task<T> Update<T>(T project, int id, string selectQuery, string updateQuery)
        {
            try
            {
                _dbConnection?.Open();

                var entity = await _dbConnection.QueryAsync<T>(selectQuery, id);

                if (entity is null)
                    return default;

                dynamic r = await _dbConnection.ExecuteScalarAsync(updateQuery, project);
                return r;
            }
            catch (Exception)
            {
                return default;
            }
            finally
            {
                _dbConnection?.Close();
            }
        }
        public async Task<bool> Delete<T>(int id, string selectQuery, string queryDelete)
        {
            try
            {
                _dbConnection?.Open();
                var entity = await _dbConnection.QueryAsync<T>(selectQuery, id);

                if (entity is null)
                    return false;
                await _dbConnection.ExecuteAsync(queryDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _dbConnection?.Close();
            }
        }
    }
}
