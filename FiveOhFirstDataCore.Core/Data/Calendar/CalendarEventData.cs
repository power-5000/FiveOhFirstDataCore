﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Core.Data.Calendar
{
    public class CalendarEventData
    {
        /// <summary>
        /// StartTime of the Event.
        /// </summary>
        public DateTime StartTime {  get; set; }
        /// <summary>
        /// EndTime of the Event.
        /// </summary>
        public DateTime EndTime {  get; set; }
        /// <summary>
        /// Title of the Event, this is what will be displayed.
        /// </summary>
        public string Title {  get; set; } = string.Empty;
        /// <summary>
        /// Extra Informatin of the Event, This will be displayed when the Event is selected.
        /// </summary>
        public string? Description {  get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CalendarEventData data &&
                StartTime == data.StartTime &&
                EndTime == data.EndTime &&
                Title == data.Title &&
                Description == data.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartTime, EndTime, Title, Description);
        }

    }
}
