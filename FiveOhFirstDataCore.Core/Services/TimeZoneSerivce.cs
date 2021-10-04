using Microsoft.JSInterop;
namespace FiveOhFirstDataCore.Data.Services;

    public class TimeZoneService : ITimeZoneService
    {
    private readonly IJSRuntime _jsRuntime;

    private TimeSpan? _userOffset;

    public TimeZoneService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async ValueTask<DateTimeOffset> GetLocalDateTimeAsync(DateTimeOffset dateTime)
    {
        if (_userOffset == null)
        {
            int offsetInMinutes = await _jsRuntime.InvokeAsync<int>("blazorGetTimezoneOffset");
            _userOffset = TimeSpan.FromMinutes(-offsetInMinutes);
        }

        return dateTime.ToOffset(_userOffset.Value);
    }

    public async ValueTask<DateTimeOffset> GetLocalDateTimeFromUTCAsync()
    {
        if (_userOffset == null)
        {
            int offsetInMinutes = await _jsRuntime.InvokeAsync<int>("blazorGetTimezoneOffset");
            _userOffset = TimeSpan.FromMinutes(-offsetInMinutes);
        }

        return DateTimeOffset.UtcNow.ToOffset(_userOffset.Value);
    }
}

