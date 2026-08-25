using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inambu_Manufacturing_Pty.Models;
using System.Diagnostics.Metrics;

namespace Inambu_Manufacturing_Pty.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
  public DbSet<ProductionLine> ProductionLines { get; set; } // registering the productionLine model
  public DbSet<Measurement> Measurements { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    // HasData populates the tables with 3 production lines
    builder.Entity<ProductionLine>().HasData( // targets the production table
      new ProductionLine { Id = 1, Name = "Production Line 1" },
      new ProductionLine { Id = 2, Name = "Production Line 2" },
      new ProductionLine { Id = 3, Name = "Production Line 3" }
    );

    builder.Entity<Measurement>(entity => {
      entity.Property(m => m.Temperature).HasPrecision(18, 2);
      entity.Property(m => m.Humidity).HasPrecision(18, 2);
      entity.Property(m => m.Weight).HasPrecision(18, 2);
      entity.Property(m => m.Width).HasPrecision(18, 2);
      entity.Property(m => m.Length).HasPrecision(18, 2);
      entity.Property(m => m.Depth).HasPrecision(18, 2);
    });
  }
}
