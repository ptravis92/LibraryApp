namespace API.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public required string Title { get; set; } 
        public int AuthorId { get; set; } 
        public required string Description { get; set; } 
        public string? CoverImage { get; set; } 
        public required string Publisher { get; set; } 
        public DateTime PublicationDate { get; set; }
        public required string Category { get; set; } 
        public required string ISBN { get; set; } 
        public int PageCount { get; set; }
        public string? CheckedOutUser { get; set; }
        public DateTime? CheckedOutUntil { get; set; }
        public required string Author  { get; set; }
    }
}