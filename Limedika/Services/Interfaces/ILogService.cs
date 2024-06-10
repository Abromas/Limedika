using Limedika.Models;

namespace Limedika.Services.Interfaces;

public interface ILogService
{
    Task LogAsync(LogEntry logEntry);
    Task<IEnumerable<LogEntry>> GetLogsAsync();
}
