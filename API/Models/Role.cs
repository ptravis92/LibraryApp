using Microsoft.AspNetCore.Identity;

namespace API.Models;

public class Role : IdentityRole<int>
{
    public required ICollection<User> Users  { get; set; }
}
