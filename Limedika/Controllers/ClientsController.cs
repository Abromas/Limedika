using EFCore.BulkExtensions;
using Limedika.Data;
using Limedika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limedika.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await _context.Clients.ToListAsync();
    }

    // GET: api/Clients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    // PUT: api/Clients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(Guid id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        _context.Entry(client).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClientExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Clients
    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }

    // POST: api/Clients/Bulk
    [HttpPost("Bulk")]
    public async Task<IActionResult> PostClientsBulk(List<Client> clients)
    {
        await _context.BulkInsertAsync(clients);
        return Ok();
    }

    // DELETE: api/Clients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Clients/Bulk
    [HttpDelete("Bulk")]
    public async Task<IActionResult> DeleteClientsBulk([FromBody] List<Guid> clientIds)
    {
        var clients = await _context.Clients.Where(c => clientIds.Contains(c.Id)).ToListAsync();
        await _context.BulkDeleteAsync(clients);
        return NoContent();
    }

    private bool ClientExists(Guid id)
    {
        return _context.Clients.Any(e => e.Id == id);
    }
}
