
using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Infraestructura.Repositorio
{
    public class EstadoCuentaRepositorio : IEstadoCuenta
    {
        private readonly IDapperContext _dapperContext;
        public EstadoCuentaRepositorio(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<EstadoCuentaDTO>> GetAll()
        {
            try
            {
                string query = @"select * from EstadoCuenta";

                var _estadocuentas = await _dapperContext.GetAll<EstadoCuentaDTO>(query);
                return _estadocuentas;
            }
            catch (Exception ex)
            {
                return new List<EstadoCuentaDTO>();
            }
        }
        public async Task<EstadoCuentaDTO?> GetById(int id)
        {
            try
            {
                string query = $@"select * from EstadoCuenta where IdEstadoCuenta = '{id}'";

                var customer = await _dapperContext.GetById<EstadoCuentaDTO>(id, query);
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<EstadoCuentaDTO?> Create(EstadoCuentaDTO _estadocuenta)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[EstadoCuenta]
           ([SaldoActual]
           ,[SaldoDisponible]
           ,[IdTarjeta]
           ,[TotalMasIntereses])
            VALUES
           (@SaldoActual
           ,@SaldoDisponible
           ,@IdTarjeta
           ,@TotalMasIntereses)";
                var id = await _dapperContext.Create(_estadocuenta, query);
                return id;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<EstadoCuentaDTO?> Update(EstadoCuentaDTO _estadocuenta)
        {
            try
            {
                string selectQuery = $@"select * from EstadoCuenta where IdEstadoCuenta = '{_estadocuenta.IdEstadoCuenta}'";

                string updateQuery = @"
UPDATE [dbo].[EstadoCuenta]
   SET [SaldoActual] = @SaldoActual
      ,[SaldoDisponible] = @SaldoDisponible
      ,[IdTarjeta] = @IdTarjeta
,[TotalMasIntereses] = @TotalMasIntereses
 WHERE IdEstadoCuenta = @IdEstadoCuenta";

                var r = await _dapperContext.Update(_estadocuenta, _estadocuenta.IdEstadoCuenta, selectQuery, updateQuery);
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
                string selectQuery = $@"select * from EstadoCuenta where IdEstadoCuenta = '{id}'";

                string query = $@"delete from EstadoCuenta where IdEstadoCuenta = '{id}'";

                var r = await _dapperContext.Delete<EstadoCuentaDTO>(id, selectQuery, query);
                return r;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<EstadoCuentaDTO>> GetListById(int Id)
        {
            try
            {
                return new List<EstadoCuentaDTO>();
            }
            catch (Exception ex)
            {
                return new List<EstadoCuentaDTO>();
            }
        }
        public async Task<List<EstadoCuentaDTO>> GetPersonalize(string query)
        {
            try
            {
                var _data = await _dapperContext.GetPersonalize<EstadoCuentaDTO>(query);
                return _data;
            }
            catch (Exception ex)
            {
                return new List<EstadoCuentaDTO>();
            }
        }
    }
}
