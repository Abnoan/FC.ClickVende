using FC.ClickVende.Data.Interfaces;
using FC.ClickVende.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FC.ClickVende.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private List<Client> _clients = new List<Client>();

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public Client GetById(Guid id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public List<Client> GetClients()
        {
            return new List<Client>(_clients);
        }

        public Client Update(Client clientUpdated)
        {
            var client = _clients.FirstOrDefault(client => client.Id == clientUpdated.Id);
            if (client != null)
            {
                client.Adress = clientUpdated.Adress;
                client.PhoneNumber = clientUpdated.PhoneNumber;
                client.CPF = clientUpdated.CPF;
                client.Email = clientUpdated.Email;
                client.Name = clientUpdated.Name;
            }

            return client;
        }

        public void Delete(Guid id)
        {
            _clients.RemoveAll(c => c.Id == id);
        }
    }
}
