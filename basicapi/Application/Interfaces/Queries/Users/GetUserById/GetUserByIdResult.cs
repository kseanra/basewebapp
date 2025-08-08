public record GetUserByIdResult
{
    public Guid UserId { get; }
    public string? Name { get; }
    public string? UserEmail { get; }

    public GetUserByIdResult(Guid userId, string? name, string? userEmail)
    {
        UserId = userId;
        Name = name;
        UserEmail = userEmail;
    }
}
