using FC.ClickVende.Business.DTOs;
using FC.ClickVende.Business.Interfaces;
using FC.ClickVende.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FC.ClickVende.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientDTO clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest("O DTO não pode ser null.");
            }

            var client = _clientService.CreateClient(clientDto);
            return Ok(client);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(Guid id)
        {
            var clientDTO = _clientService.GetClientById(id);
            if (clientDTO == null)
            {
                return NotFound($"Client with id {id} not found.");
            }
            return Ok(clientDTO);
        }

        [HttpGet]
        public IActionResult GetClientList()
        {
            var clients = _clientService.GetClients();
            if (clients == null || clients.Count == 0)
            {
                return NotFound("No clients found.");
            }
            return Ok(clients);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound($"Client with id {id} not found.");
            }
            _clientService.DeleteClient(id);
            return Ok("Client deleted successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient([FromRoute] Guid id,[FromBody] ClientDTO clientDTO)
        {
            clientDTO.Id = id;
            var retorno = _clientService.UpdateClient(clientDTO);
            if(retorno is null)
            {
                return NotFound();
            }
            return Ok(retorno);
        }
    }
}
