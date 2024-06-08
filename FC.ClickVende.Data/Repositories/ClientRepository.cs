using FC.ClickVende.Data.Interfaces;
using FC.ClickVende.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.ClickVende.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private List<Client> _clients = new();

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public Client GetById(Guid id)
        {
            var client = _clients.FirstOrDefault(client => client.Id == id);
            return client;
        }
        public List<Client> GetClients()
        {
            return _clients.ToList();
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
            _clients.RemoveAll(client => client.Id == id);
        }
    }
}