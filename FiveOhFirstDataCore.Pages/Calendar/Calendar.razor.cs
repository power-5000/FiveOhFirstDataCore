using Microsoft.AspNetCore.Components;
using FiveOhFirstDataCore.Data.Structures.Calendar;
using FiveOhFirstDataCore.Data.Extensions;
using FiveOhFirstDataCore.Data.Services;

namespace FiveOhFirstDataCore.Components.Calendar;

public partial class Calendar : ComponentBase, ICalendar
{
    private bool _visible = false;
    private int _selectedIndex;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    [Parameter]
    public string? Name { get; set; }
    [Inject]
    public ITimeZoneService? timeZoneService { get; set; }
    public TimeSpan LocalOffset => timeZoneService!.GetLocalDateTimeFromUTCAsync().Result.Offset;
    public List<ICalendarView> Views { get; set; } = new List<ICalendarView>();
    public List<CalendarEventData> CalendarEvents { get; set; } = new();
    private ICalendarView SelectedView => Views.ElementAtOrDefault(_selectedIndex)!;
    public bool IsLocal { get; set; } = false;
    public DateTime CurrentDate { get; set; } = DateTime.UtcNow.ToEst();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            LoadDummyData();
            _visible = true;
            //TODO: add importing of stored events from EventService

            StateHasChanged();
        }
    }

    public async Task CallRefreshRequest()
    {
        await InvokeAsync(StateHasChanged);
    }

    public async Task AddView(ICalendarView view)
    {
        if (!Views.Contains(view))
        {
            Views.Add(view);
            await CallRefreshRequest();
        }
    }

    public void OnChangeView(ICalendarView view)
    {
        _selectedIndex = Views.IndexOf(view);
    }

    public void RemoveView(ICalendarView view)
    {
        Views.Remove(view);
    }

    public void Today()
    {
        if (IsLocal)
        {
            CurrentDate = DateTime.UtcNow.Add(LocalOffset);
        }
        else
        {
            CurrentDate = DateTime.UtcNow.ToEst();
        }
    }

    public void OnNext()
    {
        CurrentDate = SelectedView!.Next();
    }

    public void OnPrevious()
    {
        CurrentDate = SelectedView!.Previous();
    }

    public IEnumerable<CalendarEventData> GetEventsInRange(DateTime start, DateTime end)
    {
        if (CalendarEvents == null)
        {
            return Array.Empty<CalendarEventData>();
        }

        return CalendarEvents.AsQueryable().Where(Event => Event.StartTime >= start && Event.EndTime <= end).AsEnumerable();
        //TODO: does this need to be here? As in this clasS?
    }
    public async Task SelectSlot(DateTime start, DateTime end)
    {
        //TODO: make this functional with popup window after Soy is complete with perms and using calendar service
        if (IsLocal)
        {
            CalendarEvents.Add(MakeDummyDate(start.Add(-LocalOffset), end.Add(-LocalOffset)));
        }
        else
        {
            CalendarEvents.Add(MakeDummyDate(start.FromEstToUtc(), end.FromEstToUtc()));
        }
        StateHasChanged();
    }

    public Task SelectEvent(CalendarEventData eventData)
    {
        //implemented with popup window
        throw new NotImplementedException();
    }

    public bool IsEventInRange(CalendarEventData eventdata, DateTime start, DateTime end)
    {
        if (eventdata.StartTime == eventdata.EndTime && eventdata.StartTime >= start && eventdata.EndTime < end)
        {
            return true;
        }

        return eventdata.EndTime > start && eventdata.StartTime < end;
    }

    public void IsZoneLocal(bool islocal)
    {
        if (!IsLocal == islocal)
        {
            IsLocal = islocal;
            if (IsLocal)
            {
                CurrentDate = CurrentDate.FromEstToUtc();
                CurrentDate = CurrentDate.Add(LocalOffset);
            }
            else
            {
                CurrentDate = CurrentDate.Add(-LocalOffset);
                CurrentDate = CurrentDate.ToEst();
            }
            StateHasChanged();
        }
    }

    //TODO: Delete this when done
    private void LoadDummyData()
    {
        List<CalendarEventData> sample = new List<CalendarEventData>{

        new CalendarEventData { StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddHours(1), Title = "Now" },
        new CalendarEventData { StartTime = DateTime.UtcNow.AddDays(-2), EndTime = DateTime.UtcNow.AddDays(-2), Title = "Birthday" },
        new CalendarEventData { StartTime = DateTime.UtcNow.AddDays(-1), EndTime = DateTime.UtcNow.AddDays(-10), Title = "Day off" },
        new CalendarEventData { StartTime = DateTime.UtcNow.AddDays(-5), EndTime = DateTime.UtcNow.AddDays(-8), Title = "Work from home" },
        new CalendarEventData { StartTime = DateTime.UtcNow.AddHours(12), EndTime = DateTime.UtcNow.AddHours(12).AddMinutes(30), Title = "Online meeting" },
        new CalendarEventData { StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddHours(1), Title = "Skype call" },
        new CalendarEventData { StartTime = DateTime.UtcNow.AddHours(6), EndTime = DateTime.UtcNow.AddHours(6).AddMinutes(30), Title = "Dentist appointment" },
        new CalendarEventData { StartTime = DateTime.UtcNow.AddDays(1), EndTime = DateTime.UtcNow.AddDays(12), Title = "Vacation" },
        };
        CalendarEvents = sample;
    }

    private CalendarEventData MakeDummyDate(DateTime start, DateTime end)
    {
        string[] titles = { "power b-day", "bob", "fred", "ftx", "operation", "meeting", "warroom", "other stuff", "awesomesauce" };
        CalendarEventData data1 = new();
        Random rand = new Random();
        data1.Title = titles[rand.Next(titles.Length - 1)];
        data1.StartTime = start;
        data1.EndTime = end;
        return data1;
    }
}

//TODO: Add time select for EST and LOCAL. partially complete not functional though need to figure out how the fuck this works....