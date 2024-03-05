using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class ProposalProductMap : IEntityTypeConfiguration<ProposalProduct>
{
    public void Configure(EntityTypeBuilder<ProposalProduct> builder)
    {
        builder.ToTable("proposta_produto");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("proposta_produto")
            .UseIdentityColumn()
            .IsRequired();

        builder.Property(x => x.PlanId)
            .HasColumnName("plano")
            .HasColumnType("INT")
            .IsRequired();
        
        builder.Property(x => x.ProposalId)
            .HasColumnName("proposta")
            .HasColumnType("INT")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasColumnName("ativo")
            .HasColumnType("BIT")
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("dthora")
            .HasColumnType("DATETIME")
            .IsRequired();
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnName("dtupdate")
            .HasColumnType("DATETIME")
            .IsRequired(false);

        builder.Property(x => x.Price)
            .HasColumnType("DECIMAL(14,2)")
            .HasColumnName("valor")
            .IsRequired(); 
        
        builder.Property(x => x.PriceDiscount)
            .HasColumnType("DECIMAL(14,2)")
            .HasColumnName("valor_desconto")
            .IsRequired(); 
        
        builder.Property(x => x.MembershipRate)
            .HasColumnType("DECIMAL(14,2)")
            .HasColumnName("taxa_adesao")
            .IsRequired();
        
        builder.Property(x => x.MembershipRateDiscount)
            .HasColumnType("DECIMAL(14,2)")
            .HasColumnName("taxa_adesao_desconto")
            .IsRequired();

        builder.Property(x => x.PriceTotal)
            .HasComputedColumnSql()
            .HasColumnType("DECIMAL(14,2)")
            .HasColumnName("valor_total");
        
        builder.Property(x => x.Period)
            .HasColumnType("INT")
            .HasColumnName("periodo")
            .IsRequired();

        builder.HasOne(x => x.Proposal)
            .WithOne(x => x.ProposalProduct);

        builder.HasMany(x => x.ProposalProductOptionals)
            .WithOne(x => x.ProposalProduct)
            .HasForeignKey(x => x.ProposalProductId);

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.ProposalProducts);
    }
}