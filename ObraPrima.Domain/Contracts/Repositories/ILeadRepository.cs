using ObraPrima.Domain.Context.Entities;
using ObraPrima.Domain.Context.Models;

namespace ObraPrima.Domain.Contracts.Repositories;

public interface ILeadRepository
{
    Task<List<PlanModel>?> GetProposalActiveAsync(int? id);
    Task<Lead?> GetLeadByName(string name);
}