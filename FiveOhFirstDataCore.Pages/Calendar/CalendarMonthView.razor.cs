using FiveOhFirstDataCore.Core.Data.Calendar;
using FiveOhFirstDataCore.Core.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Pages.Calendar
{
    public partial class CalendarMonthView : CalendarViewBase
    {
        public override string Text => Calendar.CurrentDate.ToString("MMMM yyyy");
        [Parameter]
        public override string Title { get; set; } = "Month";
        public ICalendar Calendar { get; set; }
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
}
