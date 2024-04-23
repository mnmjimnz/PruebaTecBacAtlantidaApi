using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bco.atlantidad.estadocuenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguracionesNegocio _neg;
        public ConfiguracionesController(IUnitOfWork unitOfWorkCliente, IConfiguracionesNegocio neg)
        {
            this._unitOfWork = unitOfWorkCliente;
            _neg = neg;
        }
        [HttpGet("GetByIdTarjeta/{IdTarjeta}")]
        public async Task<List<ConfiguracionesDTO>> GetByIdTarjeta(int IdTarjeta)
        {
            return await _neg.GetByIdTarjeta(IdTarjeta);
        }
        [HttpGet("{IdConfiguracion}")]
        public async Task<ConfiguracionesDTO> GetById(int IdConfiguracion)
        {
            return await _unitOfWork._Configuraciones.GetById(IdConfiguracion);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConfiguracionesDTO config)
        {
            try
            {
                var x = await _unitOfWork._Configuraciones.Create(config);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ConfiguracionesDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._Configuraciones.Update(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
