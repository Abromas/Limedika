namespace Limedika.Services.Interfaces;

public interface IPostCodeService
{
    Task<string?> GetPostCodeAsync(string address);
}
