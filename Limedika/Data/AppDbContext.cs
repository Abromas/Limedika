using Limedika.Models;
using Microsoft.EntityFrameworkCore;

namespace Limedika.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }
}
