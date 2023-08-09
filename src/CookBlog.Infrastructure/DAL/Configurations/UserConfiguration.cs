using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBlog.Api.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Posts).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasConversion(uid => uid.Value, g => new UserId(g));
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email)
            .HasConversion(e => e.Value, s => new Email(s))
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(u => u.UserName).IsUnique();
        builder.Property(u => u.UserName)
            .HasConversion(un => un.Value, s => new UserName(s))
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(u => u.Password)
            .HasConversion(p => p.Value, s => new Password(s))
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(u => u.FullName)
            .HasConversion(fn => fn.Value, s => new FullName(s))
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.Role)
            .HasConversion(r => r.Value, s => new Role(s))
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(u => u.CreatedAt);
    }
}
