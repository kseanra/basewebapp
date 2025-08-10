using MediatR;
public class RegistrationCommand : IRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public RegistrationCommand(string email, string password, string name)
    {
        Email = email;
        Password = password;
        Name = name;
    }
}