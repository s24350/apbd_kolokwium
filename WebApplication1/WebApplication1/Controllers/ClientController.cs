using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using WebApplication1.DTO;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
                
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }

        [HttpGet("{ClientId}")]
        public async Task<IActionResult> GetClientData([FromRoute] int IdClient)
        { 
            var clientData = await _clientRepository.GetClientData(IdClient);

            if (clientData == null)
            {
                return NoContent();
            }
            else return Ok(clientData);
        }

        [HttpPost()]
        public async Task<IActionResult> AddSubscriptionInfo([FromBody] PaymentDTO payment)
        {
            var exit = await _clientRepository.AddSubscriptionInfo(payment);
            if (exit == 1)
            {
                return BadRequest();
            }
            if (exit == 2)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
