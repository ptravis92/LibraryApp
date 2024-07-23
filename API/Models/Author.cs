namespace API.Models;

public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<Book> Books { get; set; }
}
