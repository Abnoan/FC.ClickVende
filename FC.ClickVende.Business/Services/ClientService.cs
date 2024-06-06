using FC.ClickVende.Business.DTOs;
using FC.ClickVende.Data.Models;
using FC.ClickVende.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.ClickVende.Business.Services
{
    public class ClientService
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
        public void CreateClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                CPF = clientDTO.CPF,
                Adress = clientDTO.Adress,
                PhoneNumber = clientDTO.PhoneNumber,
                Email = clientDTO.Email
            };

            _repository.Add(client);
        }

        public ClientDTO GetClientById(int id)
        {
            CreateMockClient();
            var client = _repository.GetById(id);
            if (client is null)
            {
                return null;
            }

            var clientDTO = new ClientDTO()
            {
                Id = client.Id,
                Name = client.Name,
                CPF = client.CPF,
                Adress = client.Adress,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            };

            return clientDTO;
        }

        public List<ClientDTO> GetClients()
        {
            var clients = _repository.GetClients();
            if (clients is null)
            {
                return null;
            }

            return ListToModel(clients);
        }

        public void DeleteClient(int id)
        {
            CreateMockClient();
            _repository.Delete(id);
        }

        public void UpdateClient(ClientDTO clientDTO)
        {
            CreateMockClient();
            var client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                CPF = clientDTO.CPF,
                Adress = clientDTO.Adress,
                PhoneNumber = clientDTO.PhoneNumber,
                Email = clientDTO.Email
            };

            _repository.Update(client);
        }

        #endregion

        #region Private Methods
        private void CreateMockClient()
        {
            var clientFake = new ClientDTO()
            {
                Adress = "rua sete, recife-PE",
                CPF = "12345678",
                Email = "Adam@smith.com",
                Id = 16,
                Name = "Adam Smith",
                PhoneNumber = "815555555"
            };
            CreateClient(clientFake);
        }
        private List<ClientDTO> ListToModel(List<Client> clients)
        {
            var listDto = new List<ClientDTO>();
            foreach (var client in clients)
            {
                var clientDTO = new ClientDTO()
                {
                    Name = client.Name,
                    CPF = client.CPF,
                    Adress = client.Adress,
                    PhoneNumber = client.PhoneNumber,
                    Email = client.Email
                };

                listDto.Add(clientDTO);
            }

            return listDto;
        }

        #endregion
    }
}