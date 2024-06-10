using EFCore.BulkExtensions;
using Limedika.Data;
using Limedika.Models;
using Limedika.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ClientService : IClientService
{
    private readonly AppDbContext _context;
    private readonly ILogService _logService;

    public ClientService(AppDbContext context, ILogService logService)
    {
        _context = context;
        _logService = logService;
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

        await _logService.LogAsync(new LogEntry
        {
            Action = "Entry Created",
            EntityName = nameof(Client),
            EntityId = client.Id,
            FieldName = string.Empty,
            OldValue = string.Empty,
            NewValue = $"Client: {client.Name}"
        });
    }

    public async Task AddClientsAsync(List<Client> clients)
    {
        await _context.BulkInsertAsync(clients);
        foreach (var client in clients)
        {
            await _logService.LogAsync(new LogEntry
            {
                Action = "Entry Created",
                EntityName = nameof(Client),
                EntityId = client.Id,
                FieldName = string.Empty,
                OldValue = string.Empty,
                NewValue = $"Client: {client.Name}"
            });
        }
    }

    public async Task UpdateClientAsync(Client client)
    {
        var existingClient = await _context.Clients.FindAsync(client.Id);
        if (existingClient != null)
        {
            var oldName = existingClient.Name;

            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            if (oldName != client.Name)
            {
                await _logService.LogAsync(new LogEntry
                {
                    Action = "Entry Updated",
                    EntityName = nameof(Client),
                    EntityId = client.Id,
                    FieldName = nameof(Client.Name),
                    OldValue = oldName,
                    NewValue = client.Name
                });
            }
        }
    }

    public async Task DeleteClientAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            await _logService.LogAsync(new LogEntry
            {
                Action = "Entry Deleted",
                EntityName = nameof(Client),
                EntityId = client.Id,
                FieldName = string.Empty,
                OldValue = $"Client: {client.Name}",
                NewValue = string.Empty
            });
        }
    }

    public async Task DeleteClientsAsync(List<Guid> clientIds)
    {
        var clients = await _context.Clients.Where(c => clientIds.Contains(c.Id)).ToListAsync();
        await _context.BulkDeleteAsync(clients);
        foreach (var client in clients)
        {
            await _logService.LogAsync(new LogEntry
            {
                Action = "Entry Deleted",
                EntityName = nameof(Client),
                EntityId = client.Id,
                FieldName = string.Empty,
                OldValue = $"Client: {client.Name}",
                NewValue = string.Empty
            });
        }
    }

    public bool ClientExists(Guid id)
    {
        return _context.Clients.Any(e => e.Id == id);
    }
}
