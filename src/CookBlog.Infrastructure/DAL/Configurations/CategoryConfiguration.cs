using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBlog.Api.Infrastructure.DAL.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(c => c.Posts).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(cid => cid.Value, g => new CategoryId(g));
        builder.Property(c => c.FullName)
            .IsRequired()
            .HasConversion(fn => fn.Value, s => new FullName(s));
    }
}
