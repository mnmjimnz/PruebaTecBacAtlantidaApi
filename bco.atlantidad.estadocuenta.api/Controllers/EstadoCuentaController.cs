using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bco.atlantidad.estadocuenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCuentaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEstadoCuentaNegocio _estadoCuentaNeg;
        public EstadoCuentaController(IUnitOfWork unitOfWorkCliente, IEstadoCuentaNegocio estadoCuentaNeg)
        {
            this._unitOfWork = unitOfWorkCliente;
            _estadoCuentaNeg = estadoCuentaNeg;
        }
        [HttpGet]
        public async Task<IEnumerable<EstadoCuentaDTO>> GetAll()
        {
            return await _unitOfWork._EstadoCuenta.GetAll();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstadoCuentaDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._EstadoCuenta.Create(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EstadoCuentaDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._EstadoCuenta.Update(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetEstadoCuentaByIdTarjeta/{IdTarjeta}")]
        public async Task<List<EstadoCuentaDTO>> GetEstadoCuentaByIdTarjeta(int IdTarjeta)
        {
            return await _estadoCuentaNeg.GetEstadoCuenta(IdTarjeta);
        }
        [HttpGet("GetEstadoCuentaById/{IdEstadoCuenta}")]
        public async Task<EstadoCuentaDTO> GetEstadoCuentaById(int IdEstadoCuenta)
        {
            return await _unitOfWork._EstadoCuenta.GetById(IdEstadoCuenta);
        }
    }
}
