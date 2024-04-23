using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bco.atlantidad.estadocuenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteController(IUnitOfWork unitOfWorkCliente)
        {
            this._unitOfWork = unitOfWorkCliente;
        }
        [HttpGet]
        public async Task<IEnumerable<ClienteDTO>> GetAll()
        {
            return await _unitOfWork._Cliente.GetAll();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClienteDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._Cliente.Create(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{IdCliente}")]
        public async Task<ClienteDTO> GetById(int IdCliente)
        {
            return await _unitOfWork._Cliente.GetById(IdCliente);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDTO cliente)
        {
            try
            {
                var x = await _unitOfWork._Cliente.Update(cliente);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
