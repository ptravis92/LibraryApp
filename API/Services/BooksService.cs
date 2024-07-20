using API.Models;
using API.Repositories;

namespace API.Services;

public class BooksService(BooksRepository repository)
{
    public IEnumerable<Book> Get()
    {
        return repository.Get();
    }
    public Book? Get(int id)
    {
        return repository.Get(id);
    }
}
