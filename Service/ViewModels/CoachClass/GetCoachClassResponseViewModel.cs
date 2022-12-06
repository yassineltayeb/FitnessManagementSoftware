using Service.ViewModels.Common;

namespace Service.ViewModels.CoachClass;

public class GetCoachClassResponseViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime ClassDate { get; set; }
    public int Duration { get; set; }
    public int AvailableSpaces { get; set; }
    public KeyValuePairs Coach { get; set; }
}
