using FC.ClickVende.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.ClickVende.Business.Interfaces
{
    public interface IClientService
    {
        ClientDTO CreateClient(ClientDTO clientDTO);
        ClientDTO GetClientById(Guid id);
        List<ClientDTO> GetClients();
        void DeleteClient(Guid id);
        ClientDTO UpdateClient(ClientDTO clientDTO);
    }
}
