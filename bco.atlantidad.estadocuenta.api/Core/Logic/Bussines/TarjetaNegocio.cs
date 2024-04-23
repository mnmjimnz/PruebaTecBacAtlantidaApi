using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Bussines
{
    public class TarjetaNegocio
    {
        private readonly IUnitOfWork _unitOfWork;
        public TarjetaNegocio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<List<TarjetaDTO>> GetList
    }
}
