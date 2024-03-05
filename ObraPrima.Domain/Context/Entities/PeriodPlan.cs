using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class PeriodPlan : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int PlanId { get; set; }
    public Plan? Plan { get; set; }
    public ICollection<OptionalPlan> OptionalPlans { get; set; }
}