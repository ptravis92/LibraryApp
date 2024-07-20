namespace API.Models;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int TypeId { get; set; }
}
