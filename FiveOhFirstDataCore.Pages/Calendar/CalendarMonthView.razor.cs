using FiveOhFirstDataCore.Data.Structures.Calendar;
using FiveOhFirstDataCore.Data.Extensions;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar;

public partial class CalendarMonthView
{
    public override string Text => Calendar.CurrentDate.ToString("MMMM yyyy");
    public override string Title { get; set; } = "Month";
    [Parameter]
    public override ICalendar Calendar { get; set; }
    public override DateTime StartDate => Calendar.CurrentDate.StartOfMonth();
    public override DateTime EndDate => Calendar.CurrentDate.EndOfMonth();

    public override DateTime Next()
    {
        return Calendar.CurrentDate.StartOfMonth().AddMonths(1);
    }

    public override DateTime Previous()
    {
        return Calendar.CurrentDate.StartOfMonth().AddMonths(-1);
    }

}

