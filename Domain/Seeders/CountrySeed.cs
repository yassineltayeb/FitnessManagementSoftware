using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Seeders;

public class CountrySeed
{
    private readonly ModelBuilder _modelBuilder;

    public CountrySeed(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<Country>().HasData(
            new Country() { id = 1, Name = "United Arab Emirates" }
            );
    }
}
