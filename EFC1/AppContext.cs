using EFC1.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC1;

public class AppContext: DbContext
{
    public DbSet<Show> Shows { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = App.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Show>().HasKey(Show => Show.Id);
        modelBuilder.Entity<Episode>().HasKey(Episode => Episode.Id);
    }
}