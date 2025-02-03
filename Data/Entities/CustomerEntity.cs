using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public required int Id { get; set; }
    public string CustomerName { get; set; } = null!;

    [Column(TypeName = "nvarchar(150)")]
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }

    //public int? ProjectId { get; set; } // Foreign Key
    //public ProjectEntity Project { get; set; } = null!;
}
