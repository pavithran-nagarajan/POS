using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pos.domain.Entities;

namespace pos.infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entity)
        {
            entity.ToTable("company");

            entity.HasKey(e => e.CompanyId);

            entity.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("int")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CompanyGuid)
                .HasColumnName("company_guid")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CompanyName)
                .HasColumnName("company_name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            entity.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("bit")
                .HasDefaultValue(true);

            entity.Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.CreatedDateTime)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            entity.Property(e => e.ModifiedBy)
                .HasColumnName("modified_by")
                .HasColumnType("int");

            entity.Property(e => e.ModifiedDateTime)
                .HasColumnName("modified_datetime")
                .HasColumnType("datetime2");

            // Recommended indexes
            entity.HasIndex(e => e.CompanyGuid)
                .HasDatabaseName("ix_company_company_guid")
                .IsClustered(false);
        }
    }
}
