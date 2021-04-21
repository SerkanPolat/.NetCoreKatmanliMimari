﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicMarket.Core.Models;

namespace MusicMarket.Data.Configurations
{
	public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
	{
		public void Configure(EntityTypeBuilder<Artist> builder)
		{
			builder.HasKey(a => a.Id);
			builder.Property(m => m.Id).UseIdentityColumn();
			builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
			builder.ToTable("Artists");

		}
	}
}