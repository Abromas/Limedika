using Limedika.Models;

namespace Limedika.Services.Interfaces;

public interface IClientService
{
    Task<List<Client>> GetClientsAsync();
    Task<Client> GetClientByIdAsync(Guid id);
    Task AddClientAsync(Client client);
    Task AddClientsAsync(List<Client> clients);
    Task UpdateClientAsync(Client client);
    Task DeleteClientAsync(Guid id);
    Task DeleteClientsAsync(List<Guid> clientIds);
    bool ClientExists(Guid id);
}
