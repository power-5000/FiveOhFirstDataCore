using FiveOhFirstDataCore.Core.Data.Calendar;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Pages.Calendar;

public partial class Calendar : ComponentBase, ICalendar
{
    public DateTime CurrentDate { get; set; } = DateTime.Today;
    public IList<ICalendarView> CalendarViews { get; set; } = new List<ICalendarView>();
    public int SelectedView {  get; set; } 
    private ICalendarView CalendarView => CalendarViews.ElementAtOrDefault(SelectedView);


    public Task AddView(ICalendarView view)
    {
        if (!CalendarViews.Contains(view))
        {
            CalendarViews.Add(view);
        }
        return Task.CompletedTask;//TODO
    }

    public IEnumerable<CalendarEventData> GetEventsInRange(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

    public bool IsEventInRange(CalendarEventData item, DateTime start, DateTime end)
    {
        if (item.StartTime == item.EndTime && item.StartTime >= start && item.EndTime < end)
        {
            return true;
        }
        return item.EndTime > start && item.StartTime < end;
    }

    public bool IsSelected(ICalendarView view)
    {
        throw new NotImplementedException();
    }

    public Task Reload()
    {
        throw new NotImplementedException();
    }

    public void RemoveView(ICalendarView view)
    {
        throw new NotImplementedException();
    }

    public Task SelectEvent(CalendarEventData data)
    {
        throw new NotImplementedException();
    }

    public Task SelectSlot(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

}
