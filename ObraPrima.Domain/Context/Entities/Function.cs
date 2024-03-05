using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class Function : Entity
{
    public string Name { get; set; }
    public string Key { get; set; }
    
    public ICollection<FunctionPlan>? FunctionPlans { get; set; } = null!;

}