using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class FunctionPlan : Entity
{
    public int PlanId { get; set; }
    public int FunctionId { get; set; }
    public int QuanttityLimit { get; set; }
    public Plan? Plan { get; set; }
    public Function? Function { get; set; }
}