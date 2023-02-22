using Core.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Configuration;

namespace Infrastructure.Repository;
public class RepoContext : DbContext
{
    public RepoContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HamsterConfig());
        modelBuilder.ApplyConfiguration(new BattleConfig());
    }
    public DbSet<Hamster> Hamsters { get; set; }
    public DbSet<Battle> Battles { get; set; }

    public DbSet<Plant> Plants { get; set; }
    public DbSet<PlantCategory> PlantCategories { get; set; }
}
