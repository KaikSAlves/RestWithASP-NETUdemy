using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Services;

namespace RestWithASP_NETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]
public class PersonController : ControllerBase
{
    private IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    
    //READ
    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_personService.FindAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult FindById(long id)
    {
        var person = _personService.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PersonVO person)
    {
        if(person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] PersonVO person)
    {
        if(person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }
}