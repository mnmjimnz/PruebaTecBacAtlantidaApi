using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bco.atlantidad.estadocuenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovimientosNegocio _movNeg;
        public MovimientosController(IUnitOfWork unitOfWorkCliente, IMovimientosNegocio movNeg)
        {
            this._unitOfWork = unitOfWorkCliente;
            _movNeg = movNeg;
        }
        [HttpGet]
        public async Task<IEnumerable<MovimientosDTO>> GetAll()
        {
            return await _unitOfWork._Movimientos.GetAll();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MovimientosDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._Movimientos.Create(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetComprasByIdTarjeta/{IdTarjeta}")]
        public async Task<IEnumerable<MovimientosDTO>> GetComprasByIdTarjeta(int IdTarjeta)
        {
            var x = await _movNeg.GetComprasByIdTarjeta(IdTarjeta);
            return x;
        }
        [HttpGet("GetPagosByIdTarjeta/{IdTarjeta}")]
        public async Task<IEnumerable<MovimientosDTO>> GetPagosByIdTarjeta(int IdTarjeta)
        {
            var x = await _movNeg.GetPagosByIdTarjeta(IdTarjeta);
            return x;
        }
        [HttpGet("DetalleMovimiento/{IdMovimiento}")]
        public async Task<MovimientosDTO> DetalleMovimiento(int IdMovimiento)
        {
            return await _unitOfWork._Movimientos.GetById(IdMovimiento);
        }
    }
}
