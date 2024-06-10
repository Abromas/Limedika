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
        return await _context.LogEntries.OrderByDescending(x => x.Timestamp).Take(1000).ToListAsync();
    }

    public async Task<string> GetLogsAsStringWithSizeLimitAsync(int maxSizeInBytes)
    {
        var logs = await _context.LogEntries.OrderByDescending(x => x.Timestamp).ToListAsync();
        var logString = new System.Text.StringBuilder();
        var logSize = 0;

        foreach (var log in logs)
        {
            var logEntryString = $"{log.Timestamp}\t{log.Action}\t{log.EntityName}\t{log.EntityId}\t{log.FieldName}\t{log.OldValue}\t{log.NewValue}{Environment.NewLine}";
            var entrySize = System.Text.Encoding.UTF8.GetByteCount(logEntryString);

            if (logSize + entrySize > maxSizeInBytes)
            {
                break;
            }

            logString.Append(logEntryString);
            logSize += entrySize;
        }

        return logString.ToString();
    }
}
