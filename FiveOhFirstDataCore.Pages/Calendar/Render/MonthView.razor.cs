using FiveOhFirstDataCore.Data.Structures.Calendar;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar.Render;

public partial class MonthView
{
    [Parameter]
    public DateTime StartDate {  get; set; }
    [Parameter]
    public DateTime EndDate {  get; set; }
    [Parameter]
    public IEnumerable<CalendarEventData>? Events {  get; set; }
    [CascadingParameter]
    public ICalendar? Calendar {  get; set; }

}
