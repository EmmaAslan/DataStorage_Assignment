namespace Business.Models;

public class ServiceModel
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
