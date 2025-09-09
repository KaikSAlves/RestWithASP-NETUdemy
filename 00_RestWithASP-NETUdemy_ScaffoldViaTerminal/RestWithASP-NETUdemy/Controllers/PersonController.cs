using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Hypermedia.Filters;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Services;

namespace RestWithASP_NETUdemy.Controllers;

[Authorize("Bearer")]
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
    [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))] 
    public IActionResult FindAll()
    {
        return Ok(_personService.FindAll());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)] 
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult FindById(long id)
    {
        var person = _personService.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Create([FromBody] PersonVO person)
    {
        if(person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }
    
    [HttpPut]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Update([FromBody] PersonVO person)
    {
        if(person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }
    
    [HttpPatch("disable/{id}")]
    [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Disable(long id)
    {
        var person = _personService.Disable(id);
        
        if (person == null) return NotFound("User not found");
        
        return NoContent();
    }
    
    [HttpPatch("enable/{id}")]
    [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Enable(long id)
    {
        var person = _personService.Enable(id);
        
        if (person == null) return NotFound("User not found");
        
        return NoContent();
    }
    
    [HttpGet("findPersonByName")]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)] 
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult FindByName([FromQuery] string? firstName, [FromQuery] string? lastName)
    {
        var persons = _personService.FindByName(firstName, lastName);
        if (persons == null) return NotFound();
        return Ok(persons);
    }
}