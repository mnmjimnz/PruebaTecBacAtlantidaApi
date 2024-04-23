using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Bussines
{
    public class ConfiguracionesNegocio: IConfiguracionesNegocio
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConfiguracionesNegocio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ConfiguracionesDTO>> GetByIdTarjeta(int IdTarjeta)
        {
            List<ConfiguracionesDTO> l = new List<ConfiguracionesDTO>();
            string query = $"select * from Configuraciones where IdTarjeta = {IdTarjeta}";
            try
            {
                l = await _unitOfWork._Configuraciones.GetPersonalize(query);
            }
            catch (Exception)
            {
                return null;
            }
            return l;
        }
    }
}
