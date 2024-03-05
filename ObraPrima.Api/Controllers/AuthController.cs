using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObraPrima.Application.DTOs.User;
using ObraPrima.Application.Services;
using ObraPrima.Application.Services.Contracts;

namespace ObraPrima.Api.Controllers;

[ApiController]
[Route("api/[controller]/jwt")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private const string AccsessToken = "X-Access-Token";
    [HttpPost, Route("create")]
    public async Task<IActionResult> PostAsync([FromBody] UserDTO userDto)
    {
        try
        {
            var result = await authService.Authenticate(userDto);

            if (!result.IsSuccess)
                return BadRequest(result);
            
            Response.Cookies.Append("X-Access-Token",result.Data,new CookieOptions {HttpOnly = true, SameSite = SameSiteMode.None, Secure = true});

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost, Route("refresh")]
    public async Task<ActionResult> PostAsync([FromBody] string stringa)
    {
        return Ok();
    }

    [HttpGet, Route("verify")]
    [Authorize]
    public ActionResult GetTokenValid()
    {
        if (HttpContext.User.Identity is { IsAuthenticated: false })
            return Unauthorized();

        var token = Request.Cookies[AccsessToken] ?? string.Empty;
        
       return Ok(ResultService.Ok<string>(token));
    }

    [HttpPost, Route("logout")]
    [Authorize]
    public IActionResult Post()
    {
        Response.Cookies.Delete(AccsessToken);
        
        return Ok();
    }
    
}