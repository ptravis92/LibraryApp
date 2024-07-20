namespace API.Models;

public class Review
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public int Rating { get; set; }
    public string? Body { get; set; }
}