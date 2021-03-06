﻿using System;
using System.Collections.Generic;
using System.Globalization;
using UNMealPlanner.Models;

namespace UNMealPlanner.Helpers
{
    public static class CalendarBuilder
    {
        public static string GetMonthName(int year, int month)
        {
            try
            {
                return new DateTime(year, month, 1)
                   .ToString("MMMM", CultureInfo.InvariantCulture);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static List<CalenderViewItem> GetDaysOfMonthForView(int year, int month)
        {
            var monthFullName = GetMonthName(year, month);

            var calenderViewItems = new List<CalenderViewItem>();

            var day = new DateTime(year, month, 1).DayOfWeek;

            var today = DateTime.Now.Day;

            var prevMonth = month - 1;
            var prevYear = year;
            var nextMonth = month + 1;
            var nextYear = year;
            
            if (prevMonth <= 0)
            {
                prevMonth = 12;
                prevYear -= 1;
            }

            if (nextMonth > 12)
            {
                nextMonth = 12;
                nextYear += 1;
            }

            var daysInPreviousMonth = DateTime.DaysInMonth(prevYear, prevMonth);
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
                calenderViewItems.Add(BuildItem(t, true, new DateTime(nextYear, nextMonth, t).DayOfWeek, nextMonth, nextYear, monthFullName, true));
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

        public static int GetWeekOfMonth(DateTime date)
        {
            var myCI = CultureInfo.CurrentCulture;
            var myCal = myCI.Calendar;

            var myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            var myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            return myCal.GetWeekOfYear(date, myCWR, myFirstDOW);

            //    DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            //    while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            //        date = date.AddDays(1);

            //    return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        } 
    }
}
