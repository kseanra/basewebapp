using MediatR;

public record CreateUserCommand : IRequest
{
    public string Name { get; init; }
    public string Email { get; init; }
}