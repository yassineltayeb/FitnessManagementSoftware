using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Seeders;

public class GenderSeed
{
    private readonly ModelBuilder _modelBuilder;

    public GenderSeed(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<Gender>().HasData(
            new Gender() { Id = 1, Name = "Male" },
            new Gender() { Id = 2, Name = "Female" }
            );
    }
}
