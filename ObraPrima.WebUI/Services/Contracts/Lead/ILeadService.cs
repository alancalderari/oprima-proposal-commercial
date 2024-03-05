namespace ObraPrima.WebUI.Services.Contracts.Lead;

public interface ILeadService
{
    Task<ResultService<Models.Lead.LeadDto?>> GetLeadByName(string name);
}