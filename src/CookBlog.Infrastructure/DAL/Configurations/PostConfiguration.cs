using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBlog.Api.Infrastructure.DAL.Configurations;

internal sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId);
        builder.HasMany(p => p.Tags).WithMany(c => c.Posts);
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(pid => pid.Value, g => new PostId(g));
        builder.Property(p => p.Title)
            .IsRequired()
            .HasConversion(t => t.Value, s => new Title(s));
        builder.Property(p => p.Description)
            .HasConversion(d => d.Value, s => new Description(s));
    }
}
