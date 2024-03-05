using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("pessoa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("pessoa");
        
        builder.Property(x => x.Name)
            .HasColumnName("nome");

        builder.OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("login");

        builder.Property(x => x.Password)
            .HasColumnName("senha");

        builder.Property(x => x.Active)
            .HasColumnName("ativo");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("dthora");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnName("dt_update");
    }
}