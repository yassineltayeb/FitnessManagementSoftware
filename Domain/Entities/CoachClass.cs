namespace Domain.Entities;
public class CoachClass
{
    public long Id { get; set; }
    public long CoachId { get; set; }
    public Coach? Coach { get; set; }
    public int StatusId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime ClassFrom { get; set; }
    public DateTime ClassTo { get; set; }
    public int AvailableSpaces { get; set; }
    public long CreatedAt { get; set; }
    public long UpdatedAt { get; set; }
}