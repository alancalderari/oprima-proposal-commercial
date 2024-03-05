using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class ProposalProductOptionalMap : IEntityTypeConfiguration<ProposalProductOptional>
{
    public void Configure(EntityTypeBuilder<ProposalProductOptional> builder)
    {
        builder.ToTable("proposta_produto_opcional");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("proposta_produto_opcional")
            .UseIdentityColumn();
        
        builder.Property(x => x.ProposalProductId)
            .HasColumnType("INT")
            .HasColumnName("proposta_produto")
            .IsRequired();
        
        builder.Property(x => x.PlanId)
            .HasColumnType("INT")
            .HasColumnName("plano")
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("nome")
            .IsRequired();
        
        builder.Property(x => x.PriceDiscount)
            .HasColumnName("valor_desconto")
            .HasColumnType("DECIMAL(14,2)")
            .IsRequired();
        
        builder.Property(x => x.Price)
            .HasColumnName("valor")
            .HasColumnType("DECIMAL(14,2)")
            .IsRequired();

        builder.Property(x => x.PriceTotal)
            .HasComputedColumnSql()
            .HasColumnType("DECIMAL(14,2)")
            .HasColumnName("valor_total");
        
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

        builder.HasOne(x => x.ProposalProduct)
            .WithMany(x => x.ProposalProductOptionals)
            .HasForeignKey(x => x.ProposalProductId); 
        
        builder.HasOne(x => x.Plan)
            .WithMany(x => x.ProposalProductOptionals)
            .HasForeignKey(x => x.PlanId);
    }
}