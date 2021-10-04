using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Data.Structures.Calendar;
public abstract class CalendarViewBase : ComponentBase, ICalendarView, IDisposable
{
    public abstract string Title { get; set; }
    public abstract string Text { get; }
    [CascadingParameter]
    public abstract ICalendar? Calendar { get; set; }
    public abstract DateTime Next();
    public abstract DateTime Previous();
    public abstract DateTime StartDate { get; }
    public abstract DateTime EndDate { get; }

    public abstract RenderFragment Render();

    public void Dispose()
    {
        Calendar!.RemoveView(this);
    }

}
