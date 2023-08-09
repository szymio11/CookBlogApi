using CookBlog.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL;

public sealed class MyCookBlogDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public MyCookBlogDbContext(DbContextOptions<MyCookBlogDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
