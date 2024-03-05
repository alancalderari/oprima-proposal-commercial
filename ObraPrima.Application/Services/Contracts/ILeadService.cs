using ObraPrima.Application.DTOs.Lead;

namespace ObraPrima.Application.Services.Contracts;

public interface ILeadService
{
    Task<ResultService<List<PlanDto>>> GetProposal(int id);
    Task<ResultService<LeadDto>> GetLeadByName(string name);
}