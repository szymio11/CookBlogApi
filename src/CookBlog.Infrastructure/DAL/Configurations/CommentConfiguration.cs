using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBlog.Api.Infrastructure.DAL.Configurations;

internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(cid => cid.Value, g => new CommentId(g));
        builder.Property(c => c.FullName)
            .IsRequired()
            .HasConversion(fn => fn.Value, s => new FullName(s));
        builder.Property(c => c.Description)
            .IsRequired()
            .HasConversion(d => d.Value, s => new Description(s));
    }
}
