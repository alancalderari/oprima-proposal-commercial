using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class ProposalHistory : Entity
{
    public int ProposalId { get; set; }
    public EEventType EventType { get; set; }
    public DateTime EventDate { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }
    
    public Proposal? Proposal { get; set; }
    
}
public enum EEventType 
{
    Created = 1,
    Sended  = 2,
    Refused = 3,
    Aproved  = 4,
    Signed = 5,
}