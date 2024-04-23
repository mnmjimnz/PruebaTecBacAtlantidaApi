using bco.atlantidad.estadocuenta.api.Core.DTO;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Infraestructura.Repositorio
{
    public class MovimientoRepositorio : IMovimientos
    {
        private readonly IDapperContext _dapperContext;
        public MovimientoRepositorio(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<MovimientosDTO>> GetAll()
        {
            try
            {
                string query = @"select * from Movimientos";

                var _compras = await _dapperContext.GetAll<MovimientosDTO>(query);
                return _compras.ToList();
            }
            catch (Exception ex)
            {
                return new List<MovimientosDTO>();
            }
        }
        public async Task<MovimientosDTO?> GetById(int id)
        {
            try
            {
                string query = $@"select * from Movimientos where IdMovimiento = '{id}'";
                var customer = await _dapperContext.GetById<MovimientosDTO>(id, query);
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<MovimientosDTO?> Create(MovimientosDTO _compra)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Movimientos]
           ([FechaMovimiento]
           ,[Descripcion]
           ,[Monto]
           ,[TipoMovimiento]
           ,[IdTarjeta])
            VALUES
           (@FechaMovimiento
           ,@Descripcion
           ,@Monto
           ,@TipoMovimiento
           ,@IdTarjeta
           )
            select cast(SCOPE_IDENTITY() as int)";
                var r = await _dapperContext.Create<dynamic>(_compra, query);
                _compra.IdMovimiento = r;
                return _compra;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MovimientosDTO?> Update(MovimientosDTO _compra)
        {
            try
            {
                string selectQuery = $@"select * from Movimientos where IdMovimiento = '{_compra.IdMovimiento}'";
                string updateQuery = @"UPDATE [dbo].[Movimientos]
   SET [FechaMovimiento] = @FechaMovimiento
      ,[Descripcion] = @Descripcion
      ,[Monto] = @Monto
      ,[TipoMovimiento] = @TipoMovimiento
      ,[IdTarjeta] = @IdTarjeta
 WHERE IdMovimiento = @IdMovimiento";

                var r = await _dapperContext.Update(_compra, _compra.IdMovimiento, selectQuery, updateQuery);
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
                string selectQuery = $@"select * from Movimientos where IdMovimiento = '{id}'";

                string query = $@"delete from Movimientos where IdMovimiento = '{id}'";

                var r = await _dapperContext.Delete<MovimientosDTO>(id, selectQuery, query);
                return r;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<MovimientosDTO>> GetListById(int IdTarjeta)
        {
            try
            {
                string query = $@"select * from Movimientos where IdTarjeta = '{IdTarjeta}'";

                var _tarjetas = await _dapperContext.GetListById<MovimientosDTO>(IdTarjeta, query);
                return _tarjetas.ToList();
            }
            catch (Exception ex)
            {
                return new List<MovimientosDTO>();
            }
        }
        public async Task<List<MovimientosDTO>> GetPersonalize(string query)
        {
            try
            {
                var _data = await _dapperContext.GetPersonalize<MovimientosDTO>(query);
                return _data;
            }
            catch (Exception ex)
            {
                return new List<MovimientosDTO>();
            }
        }
    }
}
