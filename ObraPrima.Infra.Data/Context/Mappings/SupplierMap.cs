using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class SupplierMap : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("crm_user");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("user_id");

        builder.Property(x => x.Name)
            .HasColumnName("name");

        builder.OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("email");

        builder.Property(x => x.Phone)
            .HasColumnName("celular");
        
        builder.Ignore(x => x.UpdatedAt);
        
        builder.Ignore(x => x.CreatedAt);
        builder.Ignore(x => x.Active);
        
        builder.HasMany(x => x.Leads)
            .WithOne(x => x.Supplier)
            .HasForeignKey(x => x.SupplierId);
    }
}