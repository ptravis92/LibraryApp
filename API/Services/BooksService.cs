using API.Models;
using API.Repositories;
using API.ViewModels;

namespace API.Services;

public class BooksService(BooksRepository repository)
{
    public IEnumerable<BookVM> Get()
    {
        return repository.Get()
        .Select(book =>
            new BookVM()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Description = book.Description,
                CoverImage = book.CoverImage,
                Publisher = book.Publisher.Name,
                Category = book.Category.Name,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                PageCount = book.PageCount,
                CheckedOutUser = book.CheckedOutUser?.Name,
                CheckedOutUntil = book.CheckedOutUntil,
                AuthorId = book.AuthorId,
            });
    }
    public BookVM? Get(int id)
    {
        var book = repository.Get(id);

        if(book != null){
            return new BookVM()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Description = book.Description,
                CoverImage = book.CoverImage,
                Publisher = book.Publisher.Name,
                Category = book.Category.Name,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                PageCount = book.PageCount,
                CheckedOutUser = book.CheckedOutUser?.Name,
                CheckedOutUntil = book.CheckedOutUntil,
                AuthorId = book.AuthorId,
            };
        }
        else
        {
            return null;
        }
    }
}
