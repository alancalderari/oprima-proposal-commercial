using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class ProposalHistoryMap : IEntityTypeConfiguration<ProposalHistory>
{
    public void Configure(EntityTypeBuilder<ProposalHistory> builder)
    {
        builder.ToTable("proposta_historico");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("proposta_historico");
        
        builder.Property(x => x.ProposalId)
            .HasColumnName("proposta");
        
        builder.Property(x => x.EventType)
            .HasColumnType("INT")
            .HasColumnName("tipo_evento");
        
        builder.Property(x => x.EventDate)
            .HasColumnType("DATETIME")
            .HasColumnName("data_evento");
        
        builder.Property(x => x.Description)
            .HasColumnType("VARCHAR(1000)")
            .HasColumnName("descricao");
        
        builder.HasOne(x => x.Proposal)
            .WithMany(x => x.ProposalHistories);
        
        builder.Ignore(x => x.Active);

        builder.Ignore(x => x.CreatedAt);

        builder.Ignore(x => x.UpdatedAt);
    }
}