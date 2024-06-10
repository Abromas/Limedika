using Limedika.Models;

namespace Limedika.Services.Interfaces;

public interface IClientService
{
    Task<List<Client>> GetClientsAsync();
    Task<Client> GetClientByIdAsync(Guid id);
    Task AddClientAsync(Client client);
    Task UpdateClientAsync(Client client);
    Task DeleteClientAsync(Guid id);
    bool ClientExists(Guid id);
}
