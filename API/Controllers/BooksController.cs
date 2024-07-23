using API.Models;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(BooksService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<BookVM>> Get()
    {
        IEnumerable<BookVM> books = service.Get();
        
        return books.ToList();
    }

    [HttpGet("{id:int}")]
    public ActionResult<BookVM> Get(int id)
    {
        BookVM? book = service.Get(id);

        if(book == null)
        {
            return NotFound();
        }

        return book;
    }
}
