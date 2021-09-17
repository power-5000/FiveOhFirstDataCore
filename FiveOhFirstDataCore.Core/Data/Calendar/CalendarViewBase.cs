using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Core.Data.Calendar
{
    public abstract class CalendarViewBase : ComponentBase, ICalendarView, IDisposable
    {
        public abstract string Title { get; set; }
        public abstract string Text { get; }
        public abstract ICalendar Calendar { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Calendar?.RemoveView(this);
        }

        protected override Task OnInitializedAsync()
        {
            Calendar?.AddView(this);
            return Task.CompletedTask;
        }

        public abstract DateTime Next();

        public abstract DateTime Previous();

        public abstract DateTime StartDate { get; }
        public abstract DateTime EndDate { get; }
    }
}