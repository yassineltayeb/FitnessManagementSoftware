using Service.ViewModels.Common;

namespace Service.ViewModels.CoachClass;

public class GetCoachClassResponseViewModel
{
    public long Id { get; set; }
    public int StatusId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime ClassDate { get; set; }
    public double Duration { get; set; }
    public int AvailableSpaces { get; set; }
    public KeyValuePairs? Coach { get; set; }
}
