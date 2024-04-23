using bco.atlantidad.estadocuenta.api.Core.DTO;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Interface
{
    public interface IDapperContext
    {
        Task<List<T>> GetAll<T>(string query);
        Task<List<T?>> GetListById<T>(int id, string query);
        Task<List<T?>> GetPersonalize<T>(string query);
        Task<T> GetById<T>(int id, string query);
        Task<T> Create<T>(T _dto, string query);
        Task<T> Update<T>(T project, int id, string selectQuery, string updateQuery);
        Task<bool> Delete<T>(int id, string selectQuery, string queryDelete);
    }
}
