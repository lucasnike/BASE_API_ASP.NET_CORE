namespace Infra.Data.Context;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configurationsAssembly = Assembly.GetAssembly(typeof(ApiContext));
        if (configurationsAssembly is not null)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(configurationsAssembly);
        }
    }
}
