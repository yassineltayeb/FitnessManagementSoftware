using System.ComponentModel;

namespace Repository.Enum;

public enum CoachClassTypeEnum
{
    [Description("Booking")] Booking = 1,
    [Description("Fully Booked")] FullyBooked = 2,
    [Description("On Progress")] OnProgress = 3,
    [Description("Finished")] Finished = 4,
    [Description("Expired")] Expired = 5,
    [Description("Canceled")] Canceled = 6,
}