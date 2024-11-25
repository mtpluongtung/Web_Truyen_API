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
	public class CommentConfigurations : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> entity)
		{
			entity.HasKey(e => e.Id).HasName("PK__comments__3213E83F79992B25");

			entity.ToTable("comments");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
			entity.Property(e => e.Content)
				.HasColumnType("text")
				.HasColumnName("content");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.StoryId).HasColumnName("story_id");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.Chapter).WithMany(p => p.Comments)
				.HasForeignKey(d => d.ChapterId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__comments__chapter__3A81B327");

			entity.HasOne(d => d.Story).WithMany(p => p.Comments)
				.HasForeignKey(d => d.StoryId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__comments__story_i__3B75D760");

			entity.HasOne(d => d.User).WithMany(p => p.Comments)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__comments__user_id__3C69FB99");
		}
	}
	
}
