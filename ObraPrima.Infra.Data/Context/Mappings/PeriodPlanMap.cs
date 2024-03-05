using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class PeriodPlanMap : IEntityTypeConfiguration<PeriodPlan>
{
    public void Configure(EntityTypeBuilder<PeriodPlan> builder)
    {
        builder.ToTable("plano_periodo");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("plano_periodo");

        builder.Property(x => x.PlanId)
            .HasColumnName("plano");
        
        builder.Property(x => x.Name)
            .HasColumnName("nome_periodo");
        
        builder.Property(x => x.Price)
            .HasPrecision(14,2)
            .HasColumnType("decimal(14,2)")
            .HasColumnName("valor_parcela");
        
        builder.Property(x => x.Active)
            .HasColumnType("bit")
            .HasColumnName("ativo");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("dthora");

        builder.Ignore(x => x.UpdatedAt);

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.PeriodPlans);
        
        builder.HasMany(x => x.OptionalPlans)
            .WithOne(x => x.PeriodPlan)
            .HasForeignKey(x => x.PeriodPlanId);
    }
}