using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(BooksService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
        IEnumerable<Book> books = service.Get();
        
        return books.ToList();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Book> Get(int id)
    {
        Book? book = service.Get(id);

        if(book == null)
        {
            return NotFound();
        }

        return book;
    }
}
