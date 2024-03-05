using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class ProposalMap : IEntityTypeConfiguration<Proposal>
{
    public void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.ToTable("proposta");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("proposta"); 
        
        builder.Property(x => x.LeadId)
            .HasColumnName("crm_deal");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnType("DATETIME")
            .HasColumnName("dthora");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnType("DATETIME")
            .HasColumnName("dtupdate");
        
        builder.Property(x => x.Active)
            .HasColumnType("BIT")
            .HasColumnName("ativo");

        builder.HasOne(x => x.Lead)
            .WithOne(x => x.Proposal);
        
        builder.HasOne(x => x.ProposalProduct)
            .WithOne(x => x.Proposal)
            .HasForeignKey<ProposalProduct>(x => x.ProposalId);

        builder.HasMany(x => x.ProposalHistories)
            .WithOne(x => x.Proposal)
            .HasForeignKey(x => x.ProposalId);
    }
}