using FiveOhFirstDataCore.Core.Data.Calendar;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Pages.Calendar;

public partial class Calendar : ICalendar
{
    public ICalendarView SelectedView { get; set; }
    public DateTime CurrentDate { get; set; } = DateTime.Now.Date;
    [Parameter]
    public IList<ICalendarView> CalendarViews { get; set; } = new List<ICalendarView>();


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
