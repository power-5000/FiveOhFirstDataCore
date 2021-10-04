using FiveOhFirstDataCore.Data.Services;
using System.Globalization;

namespace FiveOhFirstDataCore.Data.Extensions
{
    public static class DateTImeExtensions
    {
        private static TimeZoneInfo? TzInternal { get; set; } = null;
        private static TimeZoneInfo TimeZone
        {
            get
            {
                if (TzInternal is null)
                    TzInternal = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

                return TzInternal;
            }
        }

        public static DateTime ToEst(this DateTime utc)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utc, TimeZone);
        }
        /// <summary>
        /// converts a EST DateTime with kind = unspecified back to a UTC with kind as UTC
        /// 
        /// </summary>
        /// <param name="utc">kind must not be local or utc.</param>
        /// <returns>DateTime converted to UTC with kind UTC</returns>
        public static DateTime FromEstToUtc(this DateTime utc)
        {
            return TimeZoneInfo.ConvertTime(utc, TimeZone, TimeZoneInfo.Utc);
        }

        public static int DaysFromToday(this DateTime today)
        {
            return DateTime.UtcNow.Subtract(today).Days;
        }

        public static bool IsAnniversary(this DateTime date1, DateTime date2)
        {
            int date1Month = date1.Month;
            int date1Day = date1.Day;
            int date2Month = date2.Month;
            int date2Day = date2.Day;
            if ((date1Month == date2Month) && (date1Day == date2Day))
            {
                return true;
            }

            return false;
        }

        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime StartOfWeek(this DateTime date)
        {
            int diff = date.DayOfWeek - DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return date.AddDays(-diff).Date;
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return date.StartOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime EndOfWeek(this DateTime date)
        {
            return date.StartOfWeek().AddDays(6);
        }
    }
}
