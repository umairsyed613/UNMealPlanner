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
            var monthFullName = GetMonthName(year, month);

            var calenderViewItems = new List<CalenderViewItem>();

            var day = new DateTime(year, month, 1).DayOfWeek;

            var today = DateTime.Now.Day;

            var prevMonth = month - 1;
            var nextMonth = month + 1;

            var daysInPreviousMonth = DateTime.DaysInMonth(year, prevMonth);
            var daysInSelectedMonth = DateTime.DaysInMonth(year, month);

            var temp = (int)day;

            while (temp != 1)
            {
                var t = daysInPreviousMonth--;
                calenderViewItems.Add(BuildItem(t, true, new DateTime(year, prevMonth, t).DayOfWeek, prevMonth, year, monthFullName, true));
                temp--;
            }

            for (int i = 1; i <= daysInSelectedMonth; i++)
            {
                calenderViewItems.Add(BuildItem(i, false, new DateTime(year, month, i).DayOfWeek, month, year, monthFullName, i < today));
            }

            var lastDay = new DateTime(year, month, daysInSelectedMonth).DayOfWeek;

            temp = (int)lastDay;
            var j = 1;

            while (temp < 7)
            {
                var t = j++;
                calenderViewItems.Add(BuildItem(t, true, new DateTime(year, nextMonth, t).DayOfWeek, nextMonth, year, monthFullName, true));
                temp++;
            }

            return calenderViewItems;
        }

        public static List<CalenderViewItem> GetDaysOfMonthForMobileView(int year, int month)
        {
            var monthFullName = GetMonthName(year, month);

            var calenderViewItems = new List<CalenderViewItem>();
            var today = DateTime.Now.Day;

            var daysInSelectedMonth = DateTime.DaysInMonth(year, month);

            for (int i = 1; i <= daysInSelectedMonth; i++)
            {
                calenderViewItems.Add(BuildItem(i, false, new DateTime(year, month, i).DayOfWeek, month, year, monthFullName, i < today));
            }

            return calenderViewItems;
        }

        private static CalenderViewItem BuildItem(int day, bool isDisabled, DayOfWeek dayOfWeek, int month, int year, string monthName, bool isReadOnly) =>
            new CalenderViewItem(day, isDisabled, dayOfWeek, month, year, monthName, isReadOnly);
    }
}
