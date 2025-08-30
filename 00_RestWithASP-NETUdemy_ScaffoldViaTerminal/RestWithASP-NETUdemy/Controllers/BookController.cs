using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Services;
using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{api:apiVersion}")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_bookService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindById(long id)
    {
        var book = _bookService.FindById(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create([FromBody] BookVO book)
    {
        if(book == null) return BadRequest();
        return Ok(_bookService.Create(book));
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] BookVO book)
    {
        if(book == null) return BadRequest();
        return Ok(_bookService.Update(book));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _bookService.Delete(id);
        return NoContent();
    }
}