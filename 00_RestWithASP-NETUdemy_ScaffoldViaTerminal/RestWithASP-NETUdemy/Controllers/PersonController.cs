using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Business;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Business;

namespace RestWithASP_NETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]
public class PersonController : ControllerBase
{
    private IPersonBusiness _personBusiness;

    public PersonController(IPersonBusiness personService)
    {
        _personBusiness = personService;
    }
    
    //READ
    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_personBusiness.FindAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult FindById(long id)
    {
        var person = _personBusiness.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Person person)
    {
        if(person == null) return BadRequest();
        return Ok(_personBusiness.Create(person));
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] Person person)
    {
        if(person == null) return BadRequest();
        return Ok(_personBusiness.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personBusiness.Delete(id);
        return NoContent();
    }
}