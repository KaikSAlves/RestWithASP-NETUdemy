using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Services;

namespace RestWithASP_NETUdemy.Controllers;


[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]
public class AuthController : ControllerBase
{
    private ILoginService _loginService;

    public AuthController(ILoginService loginService)
    {
        _loginService = loginService;
    }
    
    [AllowAnonymous]
    [HttpPost]
    [Route("signin")]
    public IActionResult Signin([FromBody] UserVO user)
    {
        if (user == null) return BadRequest("Invalid client request");
        var token = _loginService.ValidateCredentials(user);
        if (token == null) return Unauthorized();
        return Ok(token);
    }
    
    [AllowAnonymous]
    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh([FromBody] TokenVO tokenVo)
    { 
        if(tokenVo is null) return BadRequest("Invalid client request");
        var token = _loginService.ValidateCredentials(tokenVo);
        if(token == null) return BadRequest("Invalid client request");
        return Ok(token);
    }
    
    [HttpGet]
    [Route("revoke")]
    [Authorize("Bearer")]
    public IActionResult Revoke()
    { 
        var username = User.Identity.Name;
        var result = _loginService.RevokeToken(username);
        
        if(!result) return BadRequest("Invalid client request");
        return NoContent();
    }
 
}