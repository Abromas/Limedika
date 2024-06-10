using Limedika.Data;
using Limedika.Models;
using Limedika.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Limedika.Services;

public class LogService : ILogService
{
    private readonly AppDbContext _context;

    public LogService(AppDbContext context)
    {
        _context = context;
    }

    public async Task LogAsync(LogEntry logEntry)
    {
        logEntry.Id = Guid.NewGuid();
        logEntry.Timestamp = DateTime.UtcNow;
        _context.LogEntries.Add(logEntry);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<LogEntry>> GetLogsAsync()
    {
        return await _context.LogEntries.ToListAsync();
    }
}
