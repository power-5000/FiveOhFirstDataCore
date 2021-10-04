using FiveOhFirstDataCore.Components.Calendar.Render;
using FiveOhFirstDataCore.Data.Extensions;
using FiveOhFirstDataCore.Data.Services;
using FiveOhFirstDataCore.Data.Structures.Calendar;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar;

public partial class CalendarWeekView : CalendarViewBase
{
    public override string Text => $"{StartDate:d} <--> {StartDate.EndOfWeek():d}";
    public override string Title { get; set; } = "Week";
    [CascadingParameter]
    public override ICalendar? Calendar { get; set; }
    public override DateTime StartDate => Calendar!.CurrentDate.Date.StartOfWeek();
    public override DateTime EndDate => Calendar!.CurrentDate.Date.EndOfWeek().AddDays(1);

    public TimeSpan StartTime { get; set; } = TimeSpan.FromHours(0);
    public TimeSpan EndTime { get; set; } = TimeSpan.FromHours(24);
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            base.OnAfterRender(firstRender);
            Calendar!.AddView(this);
        }
    }

    public override DateTime Next()
    {
        return Calendar!.CurrentDate.AddDays(7);
    }

    public override DateTime Previous()
    {
        return Calendar!.CurrentDate.AddDays(-7);
    }

    public override RenderFragment Render()
    {
        List<CalendarEventData> events = Calendar!.GetEventsInRange(StartDate, EndDate).ToList();
        RenderFragment render = b =>
        {
            
            b.OpenComponent<WeekView>(0);
            b.AddAttribute(1, "StartDate", StartDate);
            b.AddAttribute(2, "EndDate", EndDate);
            b.AddAttribute(3, "StartTime", StartTime);
            b.AddAttribute(4, "EndTime", EndTime);
            b.AddAttribute(5, "Events", events);
            b.CloseComponent();
        };
        return render;
    }
}



