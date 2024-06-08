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

        public Client GetById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public List<Client> GetClients()
        {
            return new List<Client>(_clients);
        }

        public void Update(Client clientToUpdate)
        {
            var client = _clients.FirstOrDefault(c => c.Id == clientToUpdate.Id);
            if (client != null)
            {
                // Atualiza os campos do objeto. A lista já contém uma referência a este objeto,
                // então não é necessário reinserir o objeto na lista.
                client.Name = clientToUpdate.Name;
                client.CPF = clientToUpdate.CPF;
                client.Address = clientToUpdate.Address;
                client.PhoneNumber = clientToUpdate.PhoneSource;
                client.Email = clientToUpdate.Email;
            }
        }

        public void Delete(int id)
        {
            _clients.RemoveAll(c => c.Id == id);
        }
    }
}
