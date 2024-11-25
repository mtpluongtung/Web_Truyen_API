using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
	public class StoryConfiguration : IEntityTypeConfiguration<Story>
	{
		public void Configure(EntityTypeBuilder<Story> entity)
		{

			entity.HasKey(e => e.Id).HasName("PK__stories__3213E83F8CC2E685");

			entity.ToTable("stories");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Author)
				.HasMaxLength(255)
				.HasColumnName("author");
			entity.Property(e => e.CoverImage)
				.HasMaxLength(255)
				.HasColumnName("cover_image");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Description)
				.HasColumnType("text")
				.HasColumnName("description");
			entity.Property(e => e.Status)
				.HasMaxLength(50)
				.HasColumnName("status");
			entity.Property(e => e.Title)
				.HasMaxLength(255)
				.HasColumnName("title");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");

			entity.HasMany(d => d.Genres).WithMany(p => p.Stories)
				.UsingEntity<Dictionary<string, object>>(
					"StoryGenre",
					r => r.HasOne<Genre>().WithMany()
						.HasForeignKey("GenreId")
						.HasConstraintName("FK__story_gen__genre__4AB81AF0"),
					l => l.HasOne<Story>().WithMany()
						.HasForeignKey("StoryId")
						.HasConstraintName("FK__story_gen__story__49C3F6B7"),
					j =>
					{
						j.HasKey("StoryId", "GenreId").HasName("PK__story_ge__57B7B482A98852FD");
						j.ToTable("story_genres");
						j.IndexerProperty<int>("StoryId").HasColumnName("story_id");
						j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
					});

		}
	}
}
