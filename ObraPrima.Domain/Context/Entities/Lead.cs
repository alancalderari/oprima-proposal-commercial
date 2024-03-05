using ObraPrima.Domain.Context.ValueObjects;
using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class Lead : Entity
{
    public int SupplierId { get; set; }
    public string? PersonName { get; set; }
    public Email Email { get; set; }
    public string? PersonPhone { get; set; }
    public string? CompanyName { get; set; }
    
    public Supplier? Supplier { get; set; }
    public Proposal? Proposal { get; set; }
}