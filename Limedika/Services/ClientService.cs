using Limedika.Data;
using Limedika.Models;
using Limedika.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Limedika.Services;

public class ClientService : IClientService
{
    private readonly AppDbContext _context;

    public ClientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetClientByIdAsync(Guid id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task AddClientAsync(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateClientAsync(Client client)
    {
        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }

    public bool ClientExists(Guid id)
    {
        return _context.Clients.Any(e => e.Id == id);
    }
}
