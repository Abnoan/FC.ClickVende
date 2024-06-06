using FC.ClickVende.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.ClickVende.Data.Repositories
{
    public class ClientRepository
    {
        private List<Client> _clients = new();

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public Client GetById(int id)
        {
            var client = _clients.FirstOrDefault(client => client.Id == id);
            return client;
        }
        public List<Client> GetClients()
        {
            return _clients.ToList();
        }

        public void Update(Client clientUpdated)
        {
            var index = _clients.FindIndex(client => client.Id == clientUpdated.Id);
            if (index != -1)
            {
                _clients[index] = clientUpdated;
            }
        }

        public void Delete(int id)
        {
            _clients.RemoveAll(client => client.Id == id);
        }
    }
}