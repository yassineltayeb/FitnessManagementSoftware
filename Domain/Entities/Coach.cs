namespace Domain.Entities;

public class Coach : User
{
    public List<CoachesTypes> CoachesTypes { get; set; }

    public Coach()
    {
        CoachesTypes = new List<CoachesTypes>();
    }
}
