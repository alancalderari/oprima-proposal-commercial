using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class FunctionPlanMap : IEntityTypeConfiguration<FunctionPlan>
{
    public void Configure(EntityTypeBuilder<FunctionPlan> builder)
    {
        builder.ToTable("plano_funcao");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("plano_funcao");
        
        builder.Property(x => x.FunctionId)
            .HasColumnName("funcao");
        
        builder.Property(x => x.PlanId)
            .HasColumnName("plano");
        
        builder.Property(x => x.QuanttityLimit)
            .HasColumnName("qtd_limite");

        builder.Ignore(x => x.Active);
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("dthora");

        builder.Ignore(x => x.UpdatedAt);
        
        builder.HasOne(x => x.Plan)
            .WithMany(x => x.FunctionPlans);
        
        builder.HasOne(x => x.Plan)
            .WithMany(x => x.FunctionPlans);
    }
}