namespace PasswordRecovery.Domain.Entities;

public class User
{
    public Guid Id { get; set;} = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string ActivateToken { get; set; } = null!;
    public bool IsActive { get; set; } = false;

}