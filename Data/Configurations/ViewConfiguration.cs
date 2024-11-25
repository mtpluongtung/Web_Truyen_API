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
	public class ViewConfiguration : IEntityTypeConfiguration<View>
	{
		public void Configure(EntityTypeBuilder<View> entity)
		{
			entity.HasKey(e => new { e.StoryId, e.ChapterId }).HasName("PK__views__017673BEF80DB8AA");

			entity.ToTable("views");

			entity.Property(e => e.StoryId).HasColumnName("story_id");
			entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
			entity.Property(e => e.ViewCount)
				.HasDefaultValue(0)
				.HasColumnName("view_count");

			entity.HasOne(d => d.Chapter).WithMany(p => p.Views)
				.HasForeignKey(d => d.ChapterId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__views__chapter_i__6FE99F9F");

			entity.HasOne(d => d.Story).WithMany(p => p.Views)
				.HasForeignKey(d => d.StoryId)
				.HasConstraintName("FK__views__story_id__6EF57B66");
		}
	}
	
}
