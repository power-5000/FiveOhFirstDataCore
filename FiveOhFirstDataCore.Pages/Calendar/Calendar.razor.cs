using Microsoft.AspNetCore.Components;
using FiveOhFirstDataCore.Core.Extensions;

namespace FiveOhFirstDataCore.Pages.Calendar;

public partial class Calendar
{
    private enum ECalendarViews
    {
        MonthView,
        WeekView,
        DayView,
        ListView
    }

    [Parameter]
    public bool ShowMonthView { get; set; } = true;
    [Parameter]
    public bool ShowWeekView { get; set; } = true;
    [Parameter]
    public bool ShowDayView { get; set; } = true;
    [Parameter]
    public bool ShowListView { get; set; } = true;
    public DateTime StartDate {  get; set; }
    public DateTime EndDate {  get; set; }
    public DateTime CurrentDate { get; set; } = DateTime.Today;
    public int SelectedView {  get; set; }

    protected override void OnParametersSet()
    {
        StartDate = CurrentDate.StartOfMonth();
        EndDate = CurrentDate.EndOfMonth();
    }

    public void Today()
    {
        StartDate = CurrentDate.StartOfMonth();
        EndDate = CurrentDate.EndOfMonth();
    }

    public void Next()
    {
        StartDate = StartDate.StartOfMonth().AddMonths(1);
        EndDate = EndDate.StartOfMonth().AddMonths(1);
    }

    public void Previous()
    {
        StartDate = StartDate.StartOfMonth().AddMonths(-1);
        EndDate = EndDate.StartOfMonth().AddMonths(-1);
    }
}
