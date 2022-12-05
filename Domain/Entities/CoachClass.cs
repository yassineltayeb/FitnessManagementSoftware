namespace Domain.Entities;
public class CoachClass
{
    public long Id { get; set; }
    public long CoachId { get; set; }
    public Coach Coach { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime ClassFrom { get; set; }
    public DateTime ClassTo { get; set; }
    public int AvailbleSpaces { get; set; }
    public long CreatedAt { get; set; }
    public long UpdatedAt { get; set; }
}