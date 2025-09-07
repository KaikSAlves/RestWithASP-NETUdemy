using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Hypermedia.Filters;
using RestWithASP_NETUdemy.Services;
using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Controllers;

[Authorize("Bearer")]
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
    [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult FindAll()
    {
        return Ok(_bookService.FindAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult FindById(long id)
    {
        var book = _bookService.FindById(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Create([FromBody] BookVO book)
    {
        if(book == null) return BadRequest();
        return Ok(_bookService.Create(book));
    }
    
    
    [HttpPut]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Update([FromBody] BookVO book)
    {
        if(book == null) return BadRequest();
        return Ok(_bookService.Update(book));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Delete(long id)
    {
        _bookService.Delete(id);
        return NoContent();
    }
}