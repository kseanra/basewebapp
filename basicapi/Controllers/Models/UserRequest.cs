namespace basicapi.Models
{
    public class UserRequest
    {
        public Guid UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? Name { get; set; }
    }
}