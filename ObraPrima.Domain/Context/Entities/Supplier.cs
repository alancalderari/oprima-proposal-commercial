using ObraPrima.Domain.Context.ValueObjects;
using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class Supplier : Entity
{
    public string Name { get; set; }
    public Email Email { get; set; }
    public string? Phone { get; set; } // Crias VO para phone.
    
    public ICollection<Lead> Leads { get; set; }
}