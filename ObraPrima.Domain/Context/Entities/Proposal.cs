using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class Proposal : Entity
{
    public int LeadId { get; set; }
    public Lead? Lead {get;set;}
    public List<ProposalHistory>? ProposalHistories {get;set;}
    public ProposalProduct? ProposalProduct { get; set; }
}