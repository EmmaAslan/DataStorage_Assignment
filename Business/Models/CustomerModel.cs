namespace Business.Models;

public class CustomerModel
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}
