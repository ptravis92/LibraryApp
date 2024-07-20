using API.Data;
using API.Models;

namespace API.Repositories;

public class BooksRepository(DataContext context)
{
    public IEnumerable<Book> Get()
    {
        return context.Books;
    }
    public Book? Get(int id)
    {
        return context.Books.Find(id);
    }
}
