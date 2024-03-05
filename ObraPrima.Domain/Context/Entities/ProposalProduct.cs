using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class ProposalProduct : Entity
{
    public int ProposalId { get; set; }
    public int PlanId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal PriceDiscount { get; set; }
    public decimal MembershipRate { get; set; }
    public decimal MembershipRateDiscount { get; set; }
    
    public int Period { get; set; }
    
    public Proposal Proposal { get; set; }
    public Plan? Plan { get; set; }
    public ICollection<ProposalProductOptional> ProposalProductOptionals { get; set; } = null!;
}