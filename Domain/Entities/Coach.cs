﻿namespace Domain.Entities;

public class Coach : BaseUser
{
    public ICollection<CoachesTypes> CoachesTypes { get; set; }
}
