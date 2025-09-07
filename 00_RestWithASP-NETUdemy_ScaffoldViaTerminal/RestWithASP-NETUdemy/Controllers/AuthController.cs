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
}