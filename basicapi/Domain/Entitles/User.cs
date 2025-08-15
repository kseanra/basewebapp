using System.ComponentModel.DataAnnotations.Schema;

namespace basicapi.Domain.Entities;

public class User
{
    [Column(TypeName = "char(36)")]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }   
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
