using FC.ClickVende.Business.DTOs;
using FC.ClickVende.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FC.ClickVende.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        public ClientController()
        {
            _clientService = new ClientService();
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientDTO clientDto)
        {
            _clientService.CreateClient(clientDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var clientDTO = _clientService.GetClientById(id);
            if (clientDTO is null)
            {
                return NotFound();
            }
            return Ok(clientDTO);
        }

        [HttpGet("GetClientList")]
        public IActionResult GetClientList()
        {
            var clients = _clientService.GetClients();
            if (clients is null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientDTO clientDTO)
        {
            if (clientDTO is null)
            {
                return NotFound();
            }
            _clientService.UpdateClient(clientDTO);

            return Ok();
        }
    }
}