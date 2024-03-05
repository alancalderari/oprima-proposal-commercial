using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Infra.Data.Context.Mappings;

public class LeadMap : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ToTable("crm_deal");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.Property(x => x.SupplierId)
            .HasColumnName("user_id");
        
        builder.Property(x => x.PersonName)
            .HasColumnName("person_name");
        
        builder.OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("person_email");
        
        builder.Property(x => x.PersonPhone)
            .HasColumnName("person_phone");

        builder.Property(x => x.CompanyName)
            .HasColumnName("org_name");
        
        builder.Property(x => x.Active)
            .HasColumnType("bit")
            .HasColumnName("active");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("add_time");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnName("update_time");

        builder.HasOne(x => x.Supplier)
            .WithMany(x => x.Leads);

        builder.HasOne(x => x.Proposal)
            .WithOne(x => x.Lead)
            .HasForeignKey<Proposal>(x => x.LeadId);
    }
}