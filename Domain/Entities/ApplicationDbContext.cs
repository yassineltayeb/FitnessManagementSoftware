using Domain.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<City> Cities { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasIndex(c => c.Email).IsUnique();
            entity.HasIndex(c => c.Phone).IsUnique();
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasIndex(c => c.Email).IsUnique();
            entity.HasIndex(c => c.Phone).IsUnique();
        });

        modelBuilder.Entity<CoachMember>(entiry =>
        {
            entiry
                .HasOne(cm => cm.Coach)
                .WithMany(c => c.CoachMember)
                .HasForeignKey(sc => sc.CoachId);

            entiry
                .HasOne(cm => cm.Member)
                .WithMany(c => c.CoachMember)
                .HasForeignKey(sc => sc.MemberId);
        });

        base.OnModelCreating(modelBuilder);

        // Seed
        // Gender
        new GenderSeed(modelBuilder).Seed();

        // Countries
        new CountrySeed(modelBuilder).Seed();

        // Cities
        new CitySeed(modelBuilder).Seed();
    }
}
