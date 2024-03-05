using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class ProposalProductOptional : Entity
{
    public int ProposalProductId { get; set; }
    public int PlanId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal PriceDiscount { get; set; }
    public decimal PriceTotal { get; set; }
    
    public Plan? Plan { get; set; }
    public ProposalProduct ProposalProduct { get; set; }
}