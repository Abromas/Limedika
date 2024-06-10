using System.ComponentModel.DataAnnotations.Schema;

namespace Limedika.Models;

public class Client
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? PostCode { get; set; }

    [NotMapped]
    public bool IsSelected { get; set; }
}
