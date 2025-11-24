namespace Infra.Data.Context.EntitiesConfiguration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(u => u.Username)
            .IsRequired()
            .HasColumnType("NVARCHAR(255)");
        
        builder.
            Property(u => u.Password)
            .IsRequired()
            .HasColumnType("NVARCHAR(255)");
    }
}
