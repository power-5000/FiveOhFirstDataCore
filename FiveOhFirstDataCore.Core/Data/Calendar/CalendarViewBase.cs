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

        [CascadingParameter]
        public ICalendar Calendar { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Calendar?.RemoveView(this);
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            //TODO: check if Title changed

            await base.SetParametersAsync(parameters);

            await Calendar.AddView(this);
        }

        public abstract DateTime Next();

        public abstract DateTime Previous();

        public abstract DateTime StartDate { get; }
        public abstract DateTime EndDate { get; }
    }
}