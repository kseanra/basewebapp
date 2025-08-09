using MediatR;
public record DeleteUserCommand(Guid Id) : IRequest
{
    public Guid Id { get; init; } = Id;
} 