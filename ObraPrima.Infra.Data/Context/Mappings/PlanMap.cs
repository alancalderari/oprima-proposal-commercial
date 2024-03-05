using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class PlanMap : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("plano");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("plano");
        
        builder.Property(x => x.Name)
            .HasColumnName("nome");
        
        builder.Property(x => x.IsOptional)
            .HasColumnName("flg_extra");
        
        builder.Property(x => x.IsTasting)
            .HasColumnName("flg_degustacao");
        
        builder.Property(x => x.Active)
            .HasColumnType("bit")
            .HasColumnName("ativo");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("dthora");

        builder.Ignore(x => x.UpdatedAt);
        
        builder.Property(x => x.IsHidden)
            .HasColumnName("esconder");

        builder.HasMany(x => x.PeriodPlans)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId);
        
        builder.HasMany(x => x.OptionalPlans)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId);
        
        builder.HasMany(x => x.FunctionPlans)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId);
        
        builder.HasMany(x => x.ProposalProducts)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId);
        
        builder.HasMany(x => x.ProposalProductOptionals)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId);
    }
}