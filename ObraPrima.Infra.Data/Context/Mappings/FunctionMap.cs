using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class FunctionMap : IEntityTypeConfiguration<Function>
{
    public void Configure(EntityTypeBuilder<Function> builder)
    {
        builder.ToTable("funcao");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("funcao");
        
        builder.Property(x => x.Name)
            .HasColumnName("nome");
        
        builder.Property(x => x.Key)
            .HasColumnName("chave");
        
        builder.Property(x => x.Active)
            .HasColumnType("bit")
            .HasColumnName("ativo");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("dthora");

        builder.Ignore(x => x.UpdatedAt);

        builder.HasMany(x => x.FunctionPlans)
            .WithOne(x => x.Function)
            .HasForeignKey(x => x.FunctionId);
    }
}