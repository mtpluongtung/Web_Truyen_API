using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
	public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
	{
		public void Configure(EntityTypeBuilder<Chapter> entity)
		{
			entity.HasKey(e => e.Id).HasName("PK__chapters__3213E83FF4108C7C");

			entity.ToTable("chapters");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.ChapterNumber).HasColumnName("chapter_number");
			entity.Property(e => e.Content)
				.HasColumnType("text")
				.HasColumnName("content");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.StoryId).HasColumnName("story_id");
			entity.Property(e => e.Title)
				.HasMaxLength(255)
				.HasColumnName("title");

			entity.HasOne(d => d.Story).WithMany(p => p.Chapters)
				.HasForeignKey(d => d.StoryId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__chapters__story___4316F928");
		}
	}
}
