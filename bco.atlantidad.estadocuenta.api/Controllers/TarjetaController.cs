using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bco.atlantidad.estadocuenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TarjetaController(IUnitOfWork unitOfWorkCliente)
        {
            this._unitOfWork = unitOfWorkCliente;
        }
        [HttpGet]
        public async Task<IEnumerable<TarjetaDTO>> GetAll()
        {
            return await _unitOfWork._Tarjeta.GetAll();
        }
        [HttpGet("DetalleTarjeta/{IdTarjeta}")]
        public async Task<TarjetaDTO> DetalleTarjeta(int IdTarjeta)
        {
            return await _unitOfWork._Tarjeta.GetById(IdTarjeta);
        }
        [HttpGet("{IdCliente}")]
        public async Task<IEnumerable<TarjetaDTO>> GetByIdCliente(int IdCliente)
        {
            return await _unitOfWork._Tarjeta.GetListById(IdCliente);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TarjetaDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._Tarjeta.Create(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TarjetaDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._Tarjeta.Update(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
