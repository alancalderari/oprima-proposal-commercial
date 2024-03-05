using Microsoft.AspNetCore.Mvc;

namespace ObraPrima.Api.Controllers;

[ApiController, Route("api/[controller]")]
public class PlanController : ControllerBase
{
    [HttpGet,Route("{id:int}")]
    public async Task<IActionResult> GetPlanAsync(int id)
    {
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetPlanAsync()
    {
        return Ok();
    }
    [HttpGet, Route("optionals")]
    public async Task<IActionResult> GetPlanOptionalsAsync()
    {
        return Ok();
    }
    
    [HttpGet, Route("period/{name}")]
    public async Task<IActionResult> GetPlanByPeriodAsync(string name)
    {
        return Ok();
    }
}