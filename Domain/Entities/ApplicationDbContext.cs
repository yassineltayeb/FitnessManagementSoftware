using Domain.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<City> Cities { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<CoachType> CoachTypes { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Coach>(entity =>
        //{
        //    entity.HasIndex(c => c.Email).IsUnique();
        //    entity.HasIndex(c => c.Phone).IsUnique();
        //});

        //modelBuilder.Entity<Member>(entity =>
        //{
        //    entity.HasIndex(c => c.Email).IsUnique();
        //    entity.HasIndex(c => c.Phone).IsUnique();
        //});

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

        modelBuilder.Entity<CoachesTypes>(entiry =>
        {
            entiry
                .HasOne(cm => cm.Coach)
                .WithMany(c => c.CoachesTypes)
                .HasForeignKey(sc => sc.CoachId);

            entiry
                .HasOne(cm => cm.CoachType)
                .WithMany(c => c.CoachesTypes)
                .HasForeignKey(sc => sc.CoachTypeId);
        });

        modelBuilder.Entity<User>(entry =>
        {
            entry.ToTable("Users")
                 .HasDiscriminator<int>("UserTypeId")
                 .HasValue<Coach>(1)
                 .HasValue<Member>(2);

            entry.HasIndex(p => new { p.Email, p.Phone}).IsUnique();
        });

        base.OnModelCreating(modelBuilder);

        // Seed
        // Gender
        new GenderSeed(modelBuilder).Seed();

        // Countries
        new CountrySeed(modelBuilder).Seed();

        // Cities
        new CitySeed(modelBuilder).Seed();

        // Coach Types
        new CoachTypeSeed(modelBuilder).Seed();
    }
}
