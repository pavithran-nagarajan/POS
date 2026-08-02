using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pos.domain.Entities;

namespace pos.infrastructure.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> entity)
        {
            entity.ToTable("auth_refresh_token");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.Token)
                .HasColumnName("token")
                .HasColumnType("varchar(500)")
                .IsRequired();

            entity.Property(e => e.ExpiresAt)
                .HasColumnName("expires_at")
                .HasColumnType("datetime2")
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            entity.Property(e => e.IsRevoked)
                .HasColumnName("is_revoked")
                .HasColumnType("bit")
                .HasDefaultValue(false);

            // Recommended indexes
            entity.HasIndex(e => e.UserId)
                .HasDatabaseName("ix_auth_refresh_token_user_id")
                .IsClustered(false);
        }
    }
}