using Microsoft.AspNetCore.Mvc;
using ObraPrima.Application.DTOs.Proposal;
using ObraPrima.Application.Services.Contracts;

namespace ObraPrima.Api.Controllers;

[ApiController, Route("api/[controller]")]
public class ProposalController(IProposalService proposalService) :  ControllerBase
{
    #region Proposal
    
        [HttpGet, Route("{proposalId:int}")]
        public async Task<IActionResult> GetProposalAsync(int proposalId)
        {
            return Ok();
        }
    
        [HttpPut, Route("{proposalId:int}")]
        public async Task<IActionResult> PutUpdateProposalAsync(int proposalId, [FromBody] object proposal)
        {
            return Ok();
        }
    
        
        [HttpPost, Route("nested")]
        public async Task<IActionResult> PostCreateProposalAsync([FromBody] ProposalDto proposal)
        {
            try
            {
                var result = await proposalService.PostCreateProposalAsync(proposal);

                if (!result.IsSuccess)
                    return BadRequest(result);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
    #endregion
    
    #region ProposalProduct
    
        [HttpGet, Route("{id:int}/products")]
        public async Task<IActionResult> GetProposalProductAsync(int id)
        {
            return Ok();
        }
    
        [HttpGet, Route("products/{id:int}")]
        public async Task<IActionResult> GetProposalProductsAsync(int id)
        {
            return Ok();
        }
        
        [HttpPut, Route("products/{id:int}")]
        public async Task<IActionResult> UpdateProposalProductAsync(int id, [FromBody] object proposalProduct)
        {
            return Ok();
        }
    
    #endregion
    
    #region ProposalProductOptional
        [HttpGet, Route("products/{id:int}/optionals")]
        public async Task<IActionResult> GetProposalProductOptional(int id)
        {
            return Ok();
        }
    
    #endregion
    
    #region ProposalHistory
        [HttpGet, Route("{proposalId:int}/history")]
        public async Task<IActionResult> GetProposalHistoryAsync(int proposalId)
        {
            return Ok();
        }
    #endregion
    
}