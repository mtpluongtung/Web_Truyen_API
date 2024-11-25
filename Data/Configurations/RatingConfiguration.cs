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
	public class RatingConfiguration : IEntityTypeConfiguration<Rating>
	{
		public void Configure(EntityTypeBuilder<Rating> entity)
		{
			entity.HasKey(e => e.Id).HasName("PK__ratings__3213E83F7A3E3E3A");

			entity.ToTable("ratings");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.StoryId).HasColumnName("story_id");
			entity.Property(e => e.UserId).HasColumnName("user_id");
			//entity.Property(e => e.Value).HasColumnName("value");

			entity.HasOne(d => d.Story).WithMany(p => p.Ratings)
				.HasForeignKey(d => d.StoryId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__ratings__story_id__3D5E1FD2");

			entity.HasOne(d => d.User).WithMany(p => p.Ratings)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__ratings__user_id__3E52440B");
		}
	}
	
}
