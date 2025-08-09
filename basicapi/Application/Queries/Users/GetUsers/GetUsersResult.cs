using basicapi.Domain.Entities;
public class GetUsersResult
{
    public IEnumerable<User> Users { get; set; } = new List<User>();
}
