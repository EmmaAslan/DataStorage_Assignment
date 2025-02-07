namespace Business.Dtos;

public class ProjectRegistrationForm
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public int? ProjectManagerId { get; set; } // Foreign Key
    public int? CustomerId { get; set; } // Foreign Key
    public int? ServiceId { get; set; } // Foreign Key
    public int? StatusTypeId { get; set; } // Foreign Key
}

