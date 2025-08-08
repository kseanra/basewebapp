namespace basicapi.Models
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}