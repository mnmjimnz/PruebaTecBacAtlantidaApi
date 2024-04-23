using bco.atlantidad.estadocuenta.api.Core.DTO;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Interface
{
    public interface IConfiguracionesNegocio
    {
        Task<List<ConfiguracionesDTO>> GetByIdTarjeta(int IdTarjeta);
    }
}
