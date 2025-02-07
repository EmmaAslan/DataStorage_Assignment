namespace Business.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public decimal TotalPrice { get; set; }

    public ProjectManagerModel ProjectManager { get; set; } = null!;
    public CustomerModel Customer { get; set; } = null!;
    public ServiceModel Service { get; set; } = null!;
    public StatusTypeModel StatusType { get; set; } = null!;


    //public int? ProjectManagerId { get; set; }
    //public int? CustomerId { get; set; }
    //public int? ServiceId { get; set; }
    //public int? StatusTypeId { get; set; }
}
