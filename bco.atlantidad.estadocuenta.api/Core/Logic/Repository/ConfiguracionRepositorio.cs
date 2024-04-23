using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Repository
{
    public class ConfiguracionRepositorio: IConfiguraciones
    {
        private readonly IDapperContext _dapperContext;
        public ConfiguracionRepositorio(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<ConfiguracionesDTO>> GetAll()
        {
            try
            {
                string query = @"select * from Configuraciones";

                var _tarjetas = await _dapperContext.GetAll<ConfiguracionesDTO>(query);
                return _tarjetas.ToList();
            }
            catch (Exception ex)
            {
                return new List<ConfiguracionesDTO>();
            }
        }
        public async Task<List<ConfiguracionesDTO>> GetListById(int IdConfiguracion)
        {
            try
            {
                string query = $@"select * from Configuraciones where IdConfiguracion = '{IdConfiguracion}'";

                var _tarjetas = await _dapperContext.GetListById<ConfiguracionesDTO>(IdConfiguracion, query);
                return _tarjetas.ToList();
            }
            catch (Exception ex)
            {
                return new List<ConfiguracionesDTO>();
            }
        }
        public async Task<ConfiguracionesDTO?> GetById(int id)
        {
            try
            {
                string query = $@"select * from Configuraciones where IdConfiguracion = '{id}'";

                var customer = await _dapperContext.GetById<ConfiguracionesDTO>(id, query);
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ConfiguracionesDTO?> Create(ConfiguracionesDTO _tarjeta)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Configuraciones]
           ([PorcentajeSaldoMin]
           ,[PorcentajeInteres]
           ,[IdTarjeta])
            VALUES
           (@PorcentajeSaldoMin
           ,@PorcentajeInteres
           ,@IdTarjeta)";
                var id = await _dapperContext.Create<ConfiguracionesDTO>(_tarjeta, query);
                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ConfiguracionesDTO?> Update(ConfiguracionesDTO _tarjeta)
        {
            try
            {
                string selectQuery = $@"select * from Configuraciones where IdConfiguracion = '{_tarjeta.IdConfiguracion}'";

                string updateQuery = @"UPDATE [dbo].[Configuraciones]
   SET [PorcentajeSaldoMin] = @PorcentajeSaldoMin
      ,[PorcentajeInteres] = @PorcentajeInteres
      ,[IdTarjeta] = @IdTarjeta
 WHERE IdConfiguracion = @IdConfiguracion";

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
                string selectQuery = $@"select * from Configuraciones where IdConfiguracion = '{id}'";

                string query = $@"delete from Configuraciones where IdConfiguracion = '{id}'";

                await _dapperContext.Delete<ConfiguracionesDTO>(id, selectQuery, query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<ConfiguracionesDTO>> GetPersonalize(string query)
        {
            try
            {
                var _data = await _dapperContext.GetPersonalize<ConfiguracionesDTO>(query);
                return _data;
            }
            catch (Exception ex)
            {
                return new List<ConfiguracionesDTO>();
            }
        }
    }
}
