using FiveOhFirstDataCore.Data.Structures.Calendar;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar.Render;

public partial class WeekView
{
    [Parameter]
    public DateTime StartDate { get; set; }

    [Parameter]
    public DateTime EndDate { get; set; }

    [Parameter]
    public TimeSpan StartTime { get; set; }

    [Parameter]
    public TimeSpan EndTime { get; set; }

    [Parameter]
    public List<CalendarEventData>? Events { get; set; }

    [CascadingParameter]
    public ICalendar? Calendar { get; set; }

    async Task OnSlotClick(DateTime date)
    {
        //TODO add popup
        await Calendar!.SelectSlot(date, date.AddMinutes(30));
    }
}

