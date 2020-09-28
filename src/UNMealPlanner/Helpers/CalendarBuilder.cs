using System;
using System.Collections.Generic;
using System.Globalization;

using UNMealPlanner.Models;

namespace UNMealPlanner.Helpers
{
    public static class CalendarBuilder
    {
        public static string GetMonthName(int year, int month)
        {
            return new DateTime(year, month, 1)
               .ToString("MMMM", CultureInfo.InvariantCulture);
        }

        public static List<CalenderViewItem> GetDaysOfMonthForView(int year, int month)
        {
            var calenderViewItems = new List<CalenderViewItem>();
            
            var day = new DateTime(year, month, 1).DayOfWeek;
            
            var daysInPreviousMonth = DateTime.DaysInMonth(year, month - 1);
            var daysInSelectedMonth = DateTime.DaysInMonth(year, month);

            var temp = (int)day;

            while (temp != 1)
            {
                calenderViewItems.Add(new CalenderViewItem(daysInPreviousMonth--, true));
                temp--;
            }

            for (int i = 1; i <= daysInSelectedMonth; i++)
            {
                calenderViewItems.Add(new CalenderViewItem(i, false));
            }

            var lastDay = new DateTime(year, month, daysInSelectedMonth).DayOfWeek;

            temp = (int)lastDay;
            var j = 1;

            while (temp >= 0)
            {
                calenderViewItems.Add(new CalenderViewItem(j++, true));
                temp--;
            }

            return calenderViewItems;
        }
    }
}
