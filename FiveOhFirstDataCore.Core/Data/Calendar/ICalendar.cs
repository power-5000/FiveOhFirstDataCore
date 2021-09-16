using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Core.Data.Calendar
{//TODO: docs
    public interface ICalendar
    {
        public IEnumerable<CalendarEventData> GetEventsInRange(DateTime start, DateTime end);
        public bool IsEventInRange(CalendarEventData item, DateTime start, DateTime end);
        public Task AddView(ICalendarView view);
        public void RemoveView(ICalendarView view);
        public bool IsSelected(ICalendarView view);
        public DateTime CurrentDate { get; set; }
        public Task SelectEvent(CalendarEventData data);
        public Task SelectSlot(DateTime start, DateTime end);
        public Task Reload();

    }
}
