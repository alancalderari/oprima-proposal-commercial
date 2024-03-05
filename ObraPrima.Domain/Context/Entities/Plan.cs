using ObraPrima.Domain.SharedContext.Entites;

namespace ObraPrima.Domain.Context.Entities;

public class Plan : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool IsOptional { get; set; }
    public bool  IsTasting { get; set; }
    public bool IsHidden { get; set; }

    public ICollection<PeriodPlan>? PeriodPlans { get; set; } = null!;
    public ICollection<OptionalPlan>? OptionalPlans { get; set; } = null!;
    public ICollection<FunctionPlan>? FunctionPlans { get; set; } = null!;
    public ICollection<ProposalProduct>? ProposalProducts { get; set; } = null!;
    public ICollection<ProposalProductOptional>? ProposalProductOptionals { get; set; } = null!;
}