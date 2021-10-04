using FiveOhFirstDataCore.Data.Structures.Calendar;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar.Render;

public partial class DaySlotEvents
{
    [CascadingParameter]
    public ICalendar? Calendar { get; set; }

    [Parameter]
    public DateTime StartDate { get; set; }

    [Parameter]
    public DateTime EndDate { get; set; }

    [Parameter]
    public IList<CalendarEventData>? Events { get; set; }

    async Task OnEventSelect(CalendarEventData data)
    {
        await Calendar!.SelectEvent(data);
    }

    private CalendarEventData[] EventsInSlot(DateTime start, DateTime end)
    {
        if (Events == null)
        {
            return Array.Empty<CalendarEventData>();
        }

        return Events.Where(item => Calendar!.IsEventInRange(item, start, end)).OrderBy(item => item.StartTime).ThenByDescending(item => item.EndTime).ToArray();
    }

    double DetermineLeft(HashSet<double> existingLefts, double width)
    {
        double left = 0;

        while (existingLefts.Contains(left))
        {
            left += width;
        }

        return left;
    }

    HashSet<double> ExistingLefts(IDictionary<CalendarEventData, double> lefts, IEnumerable<CalendarEventData> events)
    {
        var existingLefts = new HashSet<double>();

        foreach (var data in events)
        {
            if (lefts.TryGetValue(data, out var existingLeft))
            {
                existingLefts.Add(existingLeft);
            }
        }

        return existingLefts;
    }
    private IDictionary<int, int> EventGroups()
    {
        var groups = new Dictionary<int, int>();

        for (var index = 0; index < Events!.Count(); index++)
        {
            groups[index] = 0;
        }

        for (var date = StartDate; date < EndDate; date = date.AddMinutes(30))
        {
            var start = date;
            var end = start.AddMinutes(30);

            var events = EventsInSlot(start, end);

            foreach (var item in events)
            {
                var index = Events!.IndexOf(item);

                var count = groups[index];

                groups[index] = Math.Max(events.Length, count);
            }
        }

        return groups;
    }

}

//TODO: add onclick to event comonponent