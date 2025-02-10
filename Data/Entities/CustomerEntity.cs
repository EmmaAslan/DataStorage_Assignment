using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string CustomerName { get; set; } = null!;

    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}
