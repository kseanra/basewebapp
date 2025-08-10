using MediatR;
public class LoginCommand : IRequest<LoginResult>
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    public LoginCommand(string? email, string? password)
    {
        Email = email;
        Password = password;
    }
}