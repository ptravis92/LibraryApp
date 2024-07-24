using Microsoft.AspNetCore.Identity;

namespace API.Models;

public class User : IdentityUser<int>
{
    public required string Name { get; set; }
    public int RoleId { get; set; }
    public required Role Role { get; set; }
}
