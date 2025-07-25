using Microsoft.EntityFrameworkCore;
using MegaWish.Domain.Entities;

namespace MegaWish.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Zona> Zonas { get; set; }
    public DbSet<Rastreamento> Rastreamentos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Zona>().HasKey(z => z.Id);
        modelBuilder.Entity<Rastreamento>().HasKey(r => r.Id);
    }
}
