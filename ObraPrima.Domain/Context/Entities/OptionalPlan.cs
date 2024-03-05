using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class OptionalPlan : Entity
{
    public int PeriodPlanId { get; set; }
    public int PlanId { get; set; }
    public int QuanttityLimit { get; set; }
    public decimal Price { get; set; }
    public PeriodPlan? PeriodPlan { get; set; }
    public Plan? Plan { get; set; }
}