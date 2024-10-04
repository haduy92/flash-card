namespace EnglishClass.Application.Models;

public record SignUpRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}