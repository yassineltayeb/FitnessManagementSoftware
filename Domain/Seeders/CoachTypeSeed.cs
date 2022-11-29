using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Seeders;

public class CoachTypeSeed
{
    private readonly ModelBuilder _modelBuilder;

    public CoachTypeSeed(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<CoachType>().HasData(
            new CoachType() { Id = 1, Name = "Gym Instructor" },
            new CoachType() { Id = 2, Name = "Bootcamp Instructor" },
            new CoachType() { Id = 3, Name = "Crossfit Instructor" },
            new CoachType() { Id = 4, Name = "Group Exercise Instructor" },
            new CoachType() { Id = 5, Name = "Mobile Personal Trainer" },
            new CoachType() { Id = 6, Name = "Physique Trainer" },
            new CoachType() { Id = 7, Name = "Performance Personal Trainer" },
            new CoachType() { Id = 8, Name = "Lifestyle Personal Trainer" },
            new CoachType() { Id = 9, Name = "Sports Trainer" },
            new CoachType() { Id = 10, Name = "Health Coach" },
            new CoachType() { Id = 11, Name = "Cardio Trainer" }
            );
    }
}
