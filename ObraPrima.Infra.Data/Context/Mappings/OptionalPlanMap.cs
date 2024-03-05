using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class OptionalPlanMap : IEntityTypeConfiguration<OptionalPlan>
{
    public void Configure(EntityTypeBuilder<OptionalPlan> builder)
    {
        builder.ToTable("plano_extra");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("plano_extra");
        
        builder.Property(x => x.PlanId)
            .HasColumnName("extra");
        
        builder.Property(x => x.PeriodPlanId)
            .HasColumnName("plano_periodo");
        
        builder.Property(x => x.Price)
            .HasPrecision(14,2)
            .HasColumnType("decimal(14,2)")
            .HasColumnName("valor");
        
        builder.Property(x => x.QuanttityLimit)
            .HasColumnName("qtd_limite");

        builder.Property(x => x.Active)
            .HasColumnType("bit")
            .HasColumnName("ativo");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("dthora");

        builder.Ignore(x => x.UpdatedAt);
        
        builder.HasOne(x => x.Plan)
            .WithMany(x => x.OptionalPlans);
        
        builder.HasOne(x => x.PeriodPlan)
            .WithMany(x => x.OptionalPlans);
    }
}