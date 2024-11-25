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
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> entity)
		{
			entity.HasKey(e => e.Id).HasName("PK__users__3213E83FE032D2C7");

			entity.ToTable("users");

			entity.HasIndex(e => e.Email, "UQ__users__AB6E6164680CC329").IsUnique();

			entity.HasIndex(e => e.Username, "UQ__users__F3DBC572B8140229").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Email)
				.HasMaxLength(255)
				.HasColumnName("email");
			entity.Property(e => e.PasswordHash)
				.HasMaxLength(255)
				.HasColumnName("password_hash");
			entity.Property(e => e.Role)
				.HasMaxLength(50)
				.HasDefaultValue("user")
				.HasColumnName("role");
			entity.Property(e => e.Username)
				.HasMaxLength(100)
				.HasColumnName("username");

			entity.HasMany(d => d.Stories).WithMany(p => p.Users)
				.UsingEntity<Dictionary<string, object>>(
					"Favorite",
					r => r.HasOne<Story>().WithMany()
						.HasForeignKey("StoryId")
						.HasConstraintName("FK__favorites__story__4E88ABD4"),
					l => l.HasOne<User>().WithMany()
						.HasForeignKey("UserId")
						.HasConstraintName("FK__favorites__user___4D94879B"),
					j =>
					{
						j.HasKey("UserId", "StoryId").HasName("PK__favorite__CFDD0ECAF050319D");
						j.ToTable("favorites");
						j.IndexerProperty<int>("UserId").HasColumnName("user_id");
						j.IndexerProperty<int>("StoryId").HasColumnName("story_id");
					});

		}
	}
}
