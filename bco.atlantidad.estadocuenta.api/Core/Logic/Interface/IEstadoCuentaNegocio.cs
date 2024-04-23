using bco.atlantidad.estadocuenta.api.Core.DTO;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Interface
{
    public interface IEstadoCuentaNegocio
    {
        Task<List<EstadoCuentaDTO>> GetEstadoCuenta(int IdTarjeta);
    }
}
