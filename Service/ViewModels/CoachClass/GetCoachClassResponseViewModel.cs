using Service.ViewModels.Common;

namespace Service.ViewModels.CoachClass;

public class GetCoachClassResponseViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime ClassDate { get; set; }
    public double Duration { get; set; }
    public int AvailableSpaces { get; set; }
    public KeyValuePairs Coach { get; set; }
}
