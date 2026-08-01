using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pos.domain.Entities;

namespace pos.infrastructure.Configurations
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> entity)
        {
            entity.ToTable("user_account");

            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasColumnType("int")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.UserName)
                .HasColumnName("user_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            entity.Property(e => e.PasswordHash)
                .HasColumnName("password_hash")
                .HasColumnType("varchar(256)")
                .IsRequired();

            entity.Property(e => e.UserPINHash)
                .HasColumnName("user_pin_hash")
                .HasColumnType("varchar(256)")
                .IsRequired();

            entity.Property(e => e.IsSuperAdmin)
                .HasColumnName("is_super_admin")
                .HasColumnType("bit")
                .HasDefaultValue(false);

            entity.Property(e => e.StaffName)
                .HasColumnName("staff_name")
                .HasColumnType("nvarchar(100)");

            entity.Property(e => e.EmailAddress)
                .HasColumnName("email_address")
                .HasColumnType("varchar(254)");

            entity.Property(e => e.MobileNoCountryCode)
                .HasColumnName("mobile_no_country_code")
                .HasColumnType("varchar(4)");

            entity.Property(e => e.MobileNo)
                .HasColumnName("mobile_no")
                .HasColumnType("varchar(15)");

            entity.Property(e => e.IsBlocked)
                .HasColumnName("is_blocked")
                .HasColumnType("bit")
                .HasDefaultValue(false);

            entity.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("bit")
                .HasDefaultValue(true);

            entity.Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.CreatedDateTime)
                .HasColumnName("create_datetime")
                .HasColumnType("datetime2")
                .IsRequired();

            entity.Property(e => e.ModifiedBy)
                .HasColumnName("modified_by")
                .HasColumnType("int");

            entity.Property(e => e.ModifiedDateTime)
                .HasColumnName("modified_datetime")
                .HasColumnType("datetime2");

            // Recommended indexes
            entity.HasIndex(e => e.CompanyId)
                .HasDatabaseName("ix_user_account_company_id");
        }
    }
}