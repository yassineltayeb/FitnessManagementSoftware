namespace Domain.Entities;

public class CoachMember
{
    public long Id { get; set; }
    public long CoachId { get; set; }
    public Coach Coach { get; set; }
    public long MemberId { get; set; }
    public Member Member { get; set; }
}
