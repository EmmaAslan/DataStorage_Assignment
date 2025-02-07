using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    //public int ProjectId { get; set; } // Foreign Key
    //public ProjectEntity Project { get; set; } = null!;
}
