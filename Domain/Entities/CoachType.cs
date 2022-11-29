namespace Domain.Entities;

public class CoachType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<CoachesTypes> CoachesTypes { get; set; }
}
