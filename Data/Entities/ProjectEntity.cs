using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(150)")]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    public int? ProjectManagerId { get; set; } // Foreign Key
    public ProjectManagerEntity ProjectManager { get; set; } = null!;

    public int? CustomerId { get; set; } // Foreign Key
    public CustomerEntity Customer { get; set; } = null!;

    public int? ServiceId { get; set; } // Foreign Key
    public ServiceEntity Service { get; set; } = null!;

    public int? StatusTypeId { get; set; } // Foreign Key
    public StatusTypeEntity StatusType { get; set; } = null!;

}
