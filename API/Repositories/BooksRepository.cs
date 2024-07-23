using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class BooksRepository(DataContext context)
{
    public IEnumerable<Book> Get()
    {
        return context.Books
            .Include(book => book.Author)
            .Include(book => book.Publisher)
            .Include(book => book.Category)
            .Include(book => book.CheckedOutUser)
            .Take(20);
    }
    public Book? Get(int id)
    {
        return context.Books.Find(id);
    }
}
