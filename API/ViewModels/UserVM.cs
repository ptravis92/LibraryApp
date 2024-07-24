namespace API.ViewModels
{
    public class UserVM
    {
        public required string Username { get; set; }
        public required string Token { get; set; }
        public int RoleId { get; set; }
    }
}