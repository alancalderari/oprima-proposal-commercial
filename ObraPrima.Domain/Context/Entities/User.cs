using ObraPrima.Domain.Context.ValueObjects;
using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public Email Email { get; set; }
    public string Password { get; set; }
}