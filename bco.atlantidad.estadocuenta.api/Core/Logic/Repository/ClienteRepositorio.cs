using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Repository
{
    public class ClienteRepositorio: ICliente
    {
        private readonly IDapperContext _dapperContext;
        public ClienteRepositorio(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<ClienteDTO>> GetAll()
        {
            try
            {
                string query = @"select * from Cliente";
                var _clientes = await _dapperContext.GetAll<ClienteDTO>(query);
                return _clientes.ToList();
            }
            catch (Exception ex)
            {
                return new List<ClienteDTO>();
            }
        }
        public async Task<ClienteDTO?> GetById(int id)
        {
            try
            {
                string query = $@"select * from Cliente where IdCliente = '{id}'";

                var customer = await _dapperContext.GetById<ClienteDTO>(id, query);
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ClienteDTO> Create(ClienteDTO _cliente)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Cliente]
           ([NombresCliente]
           ,[ApellidosCliente])
            VALUES
           (@NombresCliente
           ,@ApellidosCliente)";
                var id = await _dapperContext.Create(_cliente, query);
                return id;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<ClienteDTO?> Update(ClienteDTO _cliente)
        {
            try
            {
                string selectQuery = $@"select * from Cliente where IdCliente = '{_cliente.IdCliente}'";
                string updateQuery = @"UPDATE [dbo].[Cliente]
   SET [NombresCliente] = @NombresCliente
      ,[ApellidosCliente] = @ApellidosCliente
 WHERE IdCliente = @IdCliente";
                var entity = await _dapperContext.Update<ClienteDTO>(_cliente, _cliente.IdCliente, selectQuery, updateQuery);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                string selectQuery = $@"select * from Cliente where IdCliente = '{id}'";
                string query = $@"delete from Cliente where IdCliente = '{id}'";
                var entity = await _dapperContext.Delete<ClienteDTO>(id, selectQuery, query);
                return entity;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<ClienteDTO>> GetListById(int Id)
        {
            try
            {
                return new List<ClienteDTO>();
            }
            catch (Exception ex)
            {
                return new List<ClienteDTO>();
            }
        }
        public async Task<List<ClienteDTO>> GetPersonalize(string query)
        {
            try
            {
                var _data = await _dapperContext.GetPersonalize<ClienteDTO>(query);
                return _data;
            }
            catch (Exception ex)
            {
                return new List<ClienteDTO>();
            }
        }
    }
}
