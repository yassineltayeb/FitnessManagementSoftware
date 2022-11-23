using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Seeders;

public class CitySeed
{
    private readonly ModelBuilder _modelBuilder;

    public CitySeed(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<City>().HasData(
            new City() { Id = 1, Name = "Abu Dhabi", CountryId = 1 },
            new City() { Id = 2, Name = "Dubai", CountryId = 1 },
            new City() { Id = 3, Name = "Sharjah", CountryId = 1 },
            new City() { Id = 4, Name = "Ras Al Khaimah", CountryId = 1 },
            new City() { Id = 5, Name = "Ajman", CountryId = 1 },
            new City() { Id = 6, Name = "Umm Al Quwain", CountryId = 1 },
            new City() { Id = 7, Name = "Fujairah", CountryId = 1 }
            );
    }
}
