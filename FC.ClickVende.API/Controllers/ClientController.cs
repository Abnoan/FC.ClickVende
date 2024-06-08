using FC.ClickVende.Business.DTOs;
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
                return BadRequest("Client data must be provided.");
            }

            _clientService.CreateClient(clientDto);
            return Ok("Client created successfully.");
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
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
        public IActionResult Delete(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound($"Client with id {id} not found.");
            }
            _clientService.DeleteClient(id);
            return Ok("Client deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientDTO clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest("Client data must be provided.");
            }

            var existingClient = _clientService.GetClientById(clientDto.Id);
            if (existingClient == null)
            {
                return NotFound($"Client with id {clientDto.Id} not found.");
            }

            _clientService.UpdateClient(clientDto);
            return Ok("Client updated successfully.");
        }
    }
}
