using ObraPrima.Domain.Context.Models;

namespace ObraPrima.Application.DTOs.Lead;
public record PlanDto
{
    public int? Id { get; set; }
    public int PlanId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int QuantityProject { get; set; }
    public int QuantityUser { get; set; }
    public int QuantityDisk { get; set; }
    public List<Optional> Optionals { get; set; }
    public Price PlanPrice { get; set; } = new();
    public decimal MembershipRate { get; set; }
    public decimal Discount { get; set; }
    public bool IsSelected { get; set; }
    public Period ProposalPeriod { get; set; }
    public record Optional
    {
        public int ExtraId { get; set; }
        public int PlanId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Discount { get; set; }   
        public Price? OptionalPrice { get; set; }
        public bool IsSelected { get; set; }
        public bool IsOptional { get; set; }
    }

    public record Price
    {
        public decimal Monthly { get; set; }
        public decimal Quarterly { get; set; }
        public decimal SemiAnnual { get; set; }
        public decimal Annual { get; set; }
    }

    public abstract record Period
    {
        private const string MONTHLY = nameof(MONTHLY);
        private const string QUARTERLY = nameof(QUARTERLY);
        private const string SEMIANNUAL = nameof(SEMIANNUAL);
        private const string ANNUAL = "Anual";

        public string Monthly
            => MONTHLY;
        public string Quarterly
            => QUARTERLY;
        public string SemiAnnual
            => SEMIANNUAL;
        public static string Annual
            => ANNUAL;
    }

    public PlanDto ToDto(PlanModel planModel)
        => new()
        {
            Name = planModel.Name,
            PlanId = planModel.PlanId,
            PlanPrice = new PlanDto.Price()
            {
                Annual = planModel.PlanPrice.Annual,
                SemiAnnual = planModel.PlanPrice.SemiAnnual,
                Quarterly = planModel.PlanPrice.Quarterly,
                Monthly = planModel.PlanPrice.Monthly,
            },
            Discount = planModel.Discount,
            IsSelected = planModel.IsSelected,
            QuantityUser = planModel.QuantityUser,
            QuantityDisk = planModel.QuantityDisk,
            QuantityProject = planModel.QuantityProject,
            MembershipRate = planModel.MembershipRate,
            Optionals = planModel.Optionals.Select(z => new PlanDto.Optional()
            {
                Name = z.Name,
                PlanId = z.PlanId,
                Discount = z.Discount,
                IsSelected = z.IsSelected,
                ExtraId = z.ExtraId,
                IsOptional = z.IsOptional,
                OptionalPrice = new PlanDto.Price
                {
                    Annual = z.OptionalPrice!.Annual,
                    SemiAnnual = z.OptionalPrice.SemiAnnual,
                    Quarterly = z.OptionalPrice.Quarterly,
                    Monthly = z.OptionalPrice.Monthly
                }
            }).ToList()
        };
}
