using BackESPD.Application.Interfaces;

namespace BackESPD.Shared.DateTimeService
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
