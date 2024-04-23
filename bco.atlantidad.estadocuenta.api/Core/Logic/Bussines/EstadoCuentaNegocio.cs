using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Bussines
{
    public class EstadoCuentaNegocio : IEstadoCuentaNegocio
    {
        private readonly IUnitOfWork _unitOfWork;
        public EstadoCuentaNegocio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EstadoCuentaDTO>> GetEstadoCuenta(int IdTarjeta)
        {
            List<EstadoCuentaDTO> l = new List<EstadoCuentaDTO>();
            string query = $"select * from EstadoCuenta where IdTarjeta = {IdTarjeta}";
            try
            {
                l = await _unitOfWork._EstadoCuenta.GetPersonalize(query);
            }
            catch (Exception)
            {
                return null;
            }
            return l;
        }
    }
}
