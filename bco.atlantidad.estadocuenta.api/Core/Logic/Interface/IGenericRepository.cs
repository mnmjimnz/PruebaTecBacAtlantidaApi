using bco.atlantidad.estadocuenta.api.Core.DTO;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Interface
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<List<T>> GetAll();
            Task<List<T?>> GetListById(int id);
            Task<T?> GetById(int id);
            Task<T> Create(T _cliente);
            Task<T?> Update(T _cliente);
            Task<bool> Delete(int id);
            Task<List<T>> GetPersonalize(string query);
        }
    }
}
