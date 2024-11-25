using System;
using System.Collections.Generic;
using System.Reflection;
using Data.Configurations;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class DocTruyenContext : DbContext
{
    public DocTruyenContext()
    {
    }

    public DocTruyenContext(DbContextOptions<DocTruyenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Story> Stories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<View> Views { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChapterConfiguration());
		modelBuilder.ApplyConfiguration(new CommentConfigurations());
		modelBuilder.ApplyConfiguration(new GenreConfigurations());
		modelBuilder.ApplyConfiguration(new RatingConfiguration());
		modelBuilder.ApplyConfiguration(new StoryConfiguration());
		modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ViewConfiguration());


		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      
    }
}
