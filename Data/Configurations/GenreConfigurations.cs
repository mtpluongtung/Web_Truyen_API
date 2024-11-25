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
	public class GenreConfigurations : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> entity)
		{
			entity.HasKey(e => e.Id).HasName("PK__genres__3213E83F935E0DF1");

			entity.ToTable("genres");

			//entity.HasIndex(e => e.Name, "UQ__genres__72E12F1BC215C2AB").IsUnique();

			//entity.Property(e => e.Id).HasColumnName("id");
			//entity.Property(e => e.Name)
			//	.HasMaxLength(100)
			//	.HasColumnName("name");
		}
	}
}
