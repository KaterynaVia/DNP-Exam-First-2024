using EFC.Entities;
using EFС.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC;

public class AppContext : DbContext
{
    public DbSet<Show> Shows { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = App.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Show>().HasKey(Show => Show.Id);
        modelBuilder.Entity<Episode>().HasKey(Episode => Episode.Id);
    }
}