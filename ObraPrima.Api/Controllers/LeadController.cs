using Microsoft.AspNetCore.Mvc;
using ObraPrima.Application.Services.Contracts;

namespace ObraPrima.Api.Controllers;

[ApiController, Route("api/[controller]")]
public class LeadController(ILeadService leadService) : ControllerBase
{
    // [HttpGet, Route("{id:int}/proposal")]
    // public async Task<ActionResult> GetProposalAsync(int id)
    // {
    //     var result = await leadService.GetProposal(id);
    //     
    //     return Ok(result);
    // }
    
    [HttpGet, Route("{id:int}")]
    public async Task<ActionResult> GetLeadAsync(int id)
    {
        return Ok();
    }
    [HttpGet, Route("{name}")]
    public async Task<ActionResult> GetLeadByNameAsync(string name)
    {
        try
        {
            var result = await leadService.GetLeadByName(name);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut, Route("{id:int}")]
    public async Task<ActionResult> PutLead(int id)
    {
        return Ok();
    }
    
    
}