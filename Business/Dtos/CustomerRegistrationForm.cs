namespace Business.Dtos;

public class CustomerRegistrationForm
{
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}

