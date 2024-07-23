namespace API.Models;

public class Book
{
 public int Id { get; set; }
 public required string Title { get; set; } 
 public int AuthorId { get; set; } 
 public required string Description { get; set; } 
 public string? CoverImage { get; set; } 
 public int PublisherId { get; set; } 
 public DateTime PublicationDate { get; set; }
 public int CategoryId { get; set; } 
 public required string ISBN { get; set; } 
 public int PageCount { get; set; }
  public int? CheckedOutUserId { get; set; }
 public DateTime? CheckedOutUntil { get; set; }
 public required Author Author { get; set; }
 public required Publisher Publisher { get; set; }
 public required Category Category { get; set; }
 public User? CheckedOutUser { get; set; }
}
