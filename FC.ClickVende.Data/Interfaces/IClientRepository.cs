namespace FC.ClickVende.Data.Interfaces
{
    public interface IClientRepository
    {
        void Add(Client client);
        Client GetById(int id);
        List<Client> GetClients();
        void Update(Client client);
        void Delete(int id);
    }
}
