public record GetUserByIdResult
{
    public Guid UserId { get; }
    public string? Name { get; }
    public string? Email { get; }

    public GetUserByIdResult(Guid userId, string? name, string? email)
    {
        UserId = userId;
        Name = name;
        Email = email;
    }
}
