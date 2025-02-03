using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectManagerEntity
{
    [Key]
    public required int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }

    //public int ProjectId { get; set; } // Foreign Key
    //public ProjectEntity Project { get; set; } = null!;
}