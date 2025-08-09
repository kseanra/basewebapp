using basicapi.Models;

public class UsersResponse
{
    public IEnumerable<UserResponse> Users { get; set; } = new List<UserResponse>();
}