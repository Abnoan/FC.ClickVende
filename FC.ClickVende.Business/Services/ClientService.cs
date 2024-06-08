using FC.ClickVende.Business.DTOs;
using FC.ClickVende.Business.Interfaces;
using FC.ClickVende.Data.Models;
using FC.ClickVende.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.ClickVende.Business.Services
{
    public class ClientService : IClientService
    {
        #region Atributos de Classe
        private readonly ClientRepository _repository;

        #endregion

        #region Construtor
        public ClientService()
        {
            _repository = new ClientRepository();
        }

        #endregion

        #region Public Methods
        public ClientDTO CreateClient(ClientDTO clientDTO)
        {
            var client = ToClient(clientDTO);
            client.Id = Guid.NewGuid();

            _repository.Add(client);
            clientDTO.Id = client.Id;
            return clientDTO;
        }

        public ClientDTO GetClientById(Guid id)
        {
            var client = _repository.GetById(id);
            if (client is null)
            {
                return null;
            }

            ClientDTO clientDTO = ToDTO(client);

            return clientDTO;
        }

        public List<ClientDTO> GetClients()
        {
            var clients = _repository.GetClients();
            if (clients is null)
            {
                return null;
            }

            return clients.Select(client => ToDTO(client)).ToList();
        }

        public ClientDTO UpdateClient(ClientDTO clientDTO)
        {
            Client client = ToClient(clientDTO);

            if (_repository.Update(client) is null)
            {
                return null;
            }

            clientDTO = ToDTO(_repository.Update(client));
            return clientDTO;
        }

        public void DeleteClient(Guid id)
        {
            _repository.Delete(id);
        }

        #endregion

        #region Private Methods
        private Client ToClient(ClientDTO clientDTO)
        {
            return new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                CPF = clientDTO.CPF,
                Adress = clientDTO.Adress,
                PhoneNumber = clientDTO.PhoneNumber,
                Email = clientDTO.Email
            };
        }

        private ClientDTO ToDTO(Client? client)
        {
            return new ClientDTO()
            {
                Id = client.Id,
                Name = client.Name,
                CPF = client.CPF,
                Adress = client.Adress,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            };
        }

        #endregion
    }
}