using FC.ClickVende.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.ClickVende.Data.Interfaces
{
    public interface IClientRepository
    {
        void Add(Client client);
        Client GetById(Guid id);
        List<Client> GetClients();
        Client Update(Client clientUpdated);
        void Delete(Guid id);
    }
}
