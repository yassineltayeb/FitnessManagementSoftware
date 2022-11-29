namespace Domain.Entities;

public class Coach : BaseUser
{
    public List<CoachesTypes> CoachesTypes { get; set; }

    public Coach()
    {
        CoachesTypes = new List<CoachesTypes>();
    }
}
