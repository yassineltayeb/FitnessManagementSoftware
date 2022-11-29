namespace Domain.Entities;

public class CoachesTypes
{
    public long Id { get; set; }
    public long CoachId { get; set; }
    public Coach Coach { get; set; }
    public int CoachTypeId { get; set; }
    public CoachType CoachType { get; set; }
}
