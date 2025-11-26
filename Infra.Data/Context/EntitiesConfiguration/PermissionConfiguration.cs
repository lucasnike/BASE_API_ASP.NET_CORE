namespace Infra.Data.Context.EntitiesConfiguration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("NVARCHAR(100)");

        builder.Property(x => x.Description)
            .HasColumnType("NVARCHAR(500)");

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
