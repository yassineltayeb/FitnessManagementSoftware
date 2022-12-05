namespace Domain.Entities;

public class Coach : User
{
    public List<CoachesTypes> CoachesTypes { get; set; }
    public List<CoachClass> CoachClasses { get; set; }

    public Coach()
    {
        CoachesTypes = new List<CoachesTypes>();
        CoachClasses = new List<CoachClass>();
    }
}
