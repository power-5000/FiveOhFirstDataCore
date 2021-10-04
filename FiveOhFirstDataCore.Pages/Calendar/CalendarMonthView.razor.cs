﻿using FiveOhFirstDataCore.Components.Calendar.Render;
using FiveOhFirstDataCore.Data.Extensions;
using FiveOhFirstDataCore.Data.Structures.Calendar;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar;

public partial class CalendarMonthView : CalendarViewBase
{
    public override string Title { get; set; } = "Month";
    public override string Text => Calendar!.CurrentDate.ToString("MMMM yyyy");
    [CascadingParameter]
    public override ICalendar? Calendar { get; set; }
    public override DateTime StartDate => Calendar!.CurrentDate.Date.StartOfMonth().StartOfWeek();
    public override DateTime EndDate => Calendar!.CurrentDate.Date.EndOfMonth().EndOfWeek().AddDays(1);

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            base.OnAfterRender(firstRender);
            Calendar!.AddView(this);
            //_advRefresh!.CallRefreshRequest("Calendar");
        }
    }

    public override DateTime Next()
    {
        return Calendar!.CurrentDate.Date.StartOfMonth().AddMonths(1);
    }

    public override DateTime Previous()
    {
        return Calendar!.CurrentDate.Date.StartOfMonth().AddMonths(-1);
    }

    public override RenderFragment Render()
    {
        List<CalendarEventData> events = Calendar!.GetEventsInRange(StartDate, EndDate).ToList();
        RenderFragment render = b =>
        {

            b.OpenComponent<MonthView>(0);
            b.AddAttribute(1, "StartDate", StartDate);
            b.AddAttribute(2, "EndDate", EndDate);
            b.AddAttribute(3, "Events", events);
            b.CloseComponent();
        };
        return render;
    }

}

