using FC.ClickVende.Business.DTOs;

namespace FC.ClickVende.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public void CreateClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                CPF = clientDTO.CPF,
                Address = clientDTO.Address,
                PhoneNumber = clientCounteract.PhoneNumber,
                Email = clientDTO.Email
            };

            _repository.Add(client);
        }

        public ClientDTO GetClientById(int id)
        {
            var client = _repository.GetById(id);
            if (client == null)
            {
                return null;
            }

            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                CPF = client.CPF,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            };
        }

        public List<ClientDTO> GetClients()
        {
            var clients = _repository.GetClients();
            return clients.Select(client => new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                CPF = client.CPF,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            }).ToList();
        }

        public void DeleteClient(int id)
        {
            _repository.Delete(id);
        }

        public void UpdateClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                CPF = clientDTO.CPF,
                Address = clientDTO.Address,
                PhoneNumber = clientDTO.PhoneNumber,
                Email = clientDTO.Email
            };

            _repository.Update(client);
        }
    }
}
