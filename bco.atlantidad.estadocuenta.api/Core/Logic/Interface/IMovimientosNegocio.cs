using bco.atlantidad.estadocuenta.api.Core.DTO;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Interface
{
    public interface IMovimientosNegocio
    {
        Task<List<MovimientosDTO>> GetComprasByIdTarjeta(int IdTarjeta);
        Task<List<MovimientosDTO>> GetPagosByIdTarjeta(int IdTarjeta);
    }
}
