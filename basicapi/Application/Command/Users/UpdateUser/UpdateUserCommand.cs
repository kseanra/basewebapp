using  MediatR;

public record UpdateUserCommand : IRequest
{
    public required Guid UserId { get; init; }
    public required string? Name { get; init; }
    public required string? Email { get; init; }
}