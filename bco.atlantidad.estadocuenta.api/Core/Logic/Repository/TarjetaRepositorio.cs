using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Repository
{
    public class TarjetaRepositorio : ITarjeta
    {
        private readonly IDapperContext _dapperContext;
        public TarjetaRepositorio(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<TarjetaDTO>> GetAll()
        {
            try
            {
                string query = @"select * from Tarjeta";

                var _tarjetas = await _dapperContext.GetAll<TarjetaDTO>(query);
                return _tarjetas.ToList();
            }
            catch (Exception ex)
            {
                return new List<TarjetaDTO>();
            }
        }
        public async Task<List<TarjetaDTO>> GetListById(int IdCliente)
        {
            try
            {
                string query = $@"select * from Tarjeta where IdCliente = '{IdCliente}'";

                var _tarjetas = await _dapperContext.GetListById<TarjetaDTO>(IdCliente ,query);
                return _tarjetas.ToList();
            }
            catch (Exception ex)
            {
                return new List<TarjetaDTO>();
            }
        }
        public async Task<TarjetaDTO?> GetById(int id)
        {
            try
            {
                string query = $@"select * from Tarjeta where IdTarjeta = '{id}'";

                var customer = await _dapperContext.GetById<TarjetaDTO>(id, query);
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TarjetaDTO?> Create(TarjetaDTO _tarjeta)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Tarjeta]
           ([NumeroTarjeta]
           ,[FechaExpiracion]
           ,[CodigoSeguridad]
           ,[Limite]
           ,[IdCliente])
            VALUES
           (@NumeroTarjeta
           ,@FechaExpiracion
           ,@CodigoSeguridad
           ,@Limite
           ,@IdCliente)";
                var id = await _dapperContext.Create<TarjetaDTO>(_tarjeta, query);
                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TarjetaDTO?> Update(TarjetaDTO _tarjeta)
        {
            try
            {
                string selectQuery = $@"select * from Tarjeta where IdTarjeta = '{_tarjeta.IdTarjeta}'";

                string updateQuery = @"UPDATE [dbo].[Tarjeta]
   SET [NumeroTarjeta] = @NumeroTarjeta
      ,[FechaExpiracion] = @FechaExpiracion
      ,[CodigoSeguridad] = @CodigoSeguridad
      ,[Limite] = @Limite
      ,[IdCliente] = @IdCliente
 WHERE IdTarjeta = @IdTarjeta";

                var r = await _dapperContext.Update(_tarjeta, _tarjeta.IdTarjeta, selectQuery, updateQuery);
                return r;
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
                string selectQuery = $@"select * from Tarjeta where IdTarjeta = '{id}'";

                string query = $@"delete from Tarjeta where IdTarjeta = '{id}'";

                await _dapperContext.Delete<TarjetaDTO>(id, selectQuery, query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<TarjetaDTO>> GetPersonalize(string query)
        {
            try
            {
                var _data = await _dapperContext.GetPersonalize<TarjetaDTO>(query);
                return _data;
            }
            catch (Exception ex)
            {
                return new List<TarjetaDTO>();
            }
        }
    }
}
