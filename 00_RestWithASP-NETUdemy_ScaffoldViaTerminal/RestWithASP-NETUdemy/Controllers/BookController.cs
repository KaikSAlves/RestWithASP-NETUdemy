using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Business;
using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{api:apiVersion}")]
public class BookController : ControllerBase
{
    private readonly IBookBusiness _bookBusiness;

    public BookController(IBookBusiness bookBusiness)
    {
        _bookBusiness = bookBusiness;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_bookBusiness.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindById(long id)
    {
        var book = _bookBusiness.FindById(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {
        if(book == null) return BadRequest();
        return Ok(_bookBusiness.Create(book));
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] Book book)
    {
        if(book == null) return BadRequest();
        return Ok(_bookBusiness.Update(book));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _bookBusiness.Delete(id);
        return NoContent();
    }
}