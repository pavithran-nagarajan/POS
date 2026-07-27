using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pos.domain.Entities;

namespace pos.infrastructure.Configurations
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> entity)
        {
            entity.ToTable("User_Account");

            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .HasColumnName("User_ID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.UserIdGuid)
                .HasColumnName("User_ID_GUID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.UserName)
                .HasColumnName("User_Name")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.PasswordHash)
                .HasColumnName("Password_Hash")
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.UserPINHash)
                .HasColumnName("User_PIN_Hash")
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.BitSuperAdmin)
                .HasColumnName("Bit_Super_Admin")
                .HasDefaultValue(false);

            entity.Property(e => e.StaffName)
                .HasColumnName("Staff_Name")
                .HasMaxLength(100);

            entity.Property(e => e.EmailAddress)
                .HasColumnName("Email_Address")
                .HasMaxLength(254);

            entity.Property(e => e.MobileNoCountryCode)
                .HasColumnName("Mobile_No_Country_Code")
                .HasMaxLength(4);

            entity.Property(e => e.MobileNo)
                .HasColumnName("Mobile_No")
                .HasMaxLength(15);

            entity.Property(e => e.BitBlocked)
                .HasColumnName("Bit_Blocked")
                .HasDefaultValue(false);

            entity.Property(e => e.BitActive)
                .HasColumnName("Bit_Active")
                .HasDefaultValue(true);

            entity.Property(e => e.CreatedBy)
                .HasColumnName("Created_By")
                .IsRequired();

            entity.Property(e => e.CreatedDateTime)
                .HasColumnName("Created_DateTime")
                .IsRequired();

            entity.Property(e => e.ModifiedBy)
                .HasColumnName("Modified_By");

            entity.Property(e => e.ModifiedDateTime)
                .HasColumnName("Modified_DateTime");

            // Recommended indexes
            entity.HasIndex(e => e.UserName).IsUnique();
            entity.HasIndex(e => e.UserIdGuid).IsUnique();
        }
    }
}