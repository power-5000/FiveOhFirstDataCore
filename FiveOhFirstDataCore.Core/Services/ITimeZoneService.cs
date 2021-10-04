namespace FiveOhFirstDataCore.Data.Services;

public interface ITimeZoneService
{
    public ValueTask<DateTimeOffset> GetLocalDateTimeAsync(DateTimeOffset dateTime);
    public ValueTask<DateTimeOffset> GetLocalDateTimeFromUTCAsync();
}

