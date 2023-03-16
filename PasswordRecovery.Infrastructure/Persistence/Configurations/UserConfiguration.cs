using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.VerificationToken)
                .HasColumnName("VerificationToken");

            builder.Property(x => x.VerifiedAt)
                .HasColumnName("VerifiedAt");

            builder.Property(x => x.PasswordResetToken)
                .HasColumnName("PasswordResetToken");

            builder.Property(x => x.ResetTokenExpires)
                .HasColumnName("ResetTokenExpires");

            builder.Property(x => x.Token)
                .HasColumnName("Token")
                .IsRequired();
        }
    }
}