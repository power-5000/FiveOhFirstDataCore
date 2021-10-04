using FiveOhFirstDataCore.Data.Services;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar;

public partial class CalendarHome : ComponentBase
{

    [Inject]
    public ITimeZoneService? TimeZoneService { get; set; }
    public DateTimeOffset Mytime { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Mytime = await TimeZoneService!.GetLocalDateTimeFromUTCAsync();
    }
}

