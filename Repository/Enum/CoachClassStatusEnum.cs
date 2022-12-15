using System.ComponentModel;

namespace Repository.Enum;

public enum CoachClassStatusEnum
{
    [Description("Booking")] Booking = 1,
    [Description("On Progress")] OnProgress = 2,
    [Description("Finished")] Finished = 3,
    [Description("Canceled")] Canceled = 4
}