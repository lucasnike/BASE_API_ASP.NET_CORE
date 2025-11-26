namespace Infra.Data.Context.EntitiesConfiguration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.
            Property(u => u.Token)
            .IsRequired()
            .HasColumnType("NVARCHAR(100)");

        builder
            .HasIndex(x => x.Token)
            .IsUnique();
    }
}
