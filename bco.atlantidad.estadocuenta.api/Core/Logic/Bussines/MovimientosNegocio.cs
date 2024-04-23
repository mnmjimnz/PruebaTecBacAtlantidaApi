using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Bussines
{
    public class MovimientosNegocio : IMovimientosNegocio
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovimientosNegocio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<MovimientosDTO>> GetComprasByIdTarjeta(int IdTarjeta)
        {
            List<MovimientosDTO> l = new List<MovimientosDTO>();
            string query = $"select * from Movimientos where IdTarjeta = {IdTarjeta} and TipoMovimiento={1}";
            try
            {
                l = await _unitOfWork._Movimientos.GetPersonalize(query);
            }
            catch (Exception)
            {
                return null;
            }
            return l;
        }
        public async Task<List<MovimientosDTO>> GetPagosByIdTarjeta(int IdTarjeta)
        {
            List<MovimientosDTO> l = new List<MovimientosDTO>();
            string query = $"select * from Movimientos where IdTarjeta = {IdTarjeta} and TipoMovimiento={2}";
            try
            {
                l = await _unitOfWork._Movimientos.GetPersonalize(query);
            }
            catch (Exception)
            {
                return null;
            }
            return l;
        }
    }
}
