namespace FC.ClickVende.Business.Interfaces
{
    public interface IClientService
    {
        void CreateClient(ClientDTO clientDTO);
        ClientDTO GetClientById(int id);
        List<ClientDTO> GetClients();
        void DeleteClient(int id);
        void UpdateClient(ClientDTO clientDTO);
    }
}
