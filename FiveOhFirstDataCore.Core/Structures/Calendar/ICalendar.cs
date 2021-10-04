using FiveOhFirstDataCore.Data.Services;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Data.Structures.Calendar;
//TODO: docs
public interface ICalendar
{
    public ITimeZoneService? timeZoneService { get; set; }
    public DateTime CurrentDate { get; set; }
    public List<ICalendarView> Views { get; set; }
    string? Name { get; set; }
    RenderFragment? ChildContent { get; set; }
    List<CalendarEventData> CalendarEvents { get; set; }
    public bool IsLocal { get; set; }
    TimeSpan LocalOffset { get; }

    Task AddView(ICalendarView view);
    void RemoveView(ICalendarView view);
    void Today();
    void OnNext();
    void OnPrevious();
    Task SelectEvent(CalendarEventData eventData);
    bool IsEventInRange(CalendarEventData eventdata, DateTime start, DateTime end);
    IEnumerable<CalendarEventData> GetEventsInRange(DateTime start, DateTime end);
    Task SelectSlot(DateTime start, DateTime end);
}

