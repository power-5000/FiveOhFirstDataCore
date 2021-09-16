using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Core.Data.Calendar
{
    /// <summary>
    /// A view for a Calendar Component. This allows implementation of a month or week view for example.
    /// </summary>
    public interface ICalendarView
    {
        /// <summary>
        /// StartDate of the view, such as first of the month or week.
        /// </summary>
        public DateTime StartDate { get; }
        /// <summary>
        /// EndDate of the view such, as last day of the month or week.
        /// </summary>
        public DateTime EndDate { get; }
        /// <summary>
        /// Title of the view such, as month or week.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Displayed text for the view to show what the calendar scope is for the view.
        /// </summary>
        public string Text { get; }
        /// <summary>
        /// Gives the next Iteration of the View the following month or week.
        /// </summary>
        /// <returns>A DateTime for the next period for this View</returns>
        public DateTime Next();
        /// <summary>
        /// Gives the previous Iteration of the View the following month or week.
        /// </summary>
        /// <returns>A DateTime for the last period for this View</returns>
        public DateTime Previous();
    }
}
