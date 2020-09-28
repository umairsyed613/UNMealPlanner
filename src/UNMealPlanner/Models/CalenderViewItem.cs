using System;

namespace UNMealPlanner.Models
{
    public class CalenderViewItem
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string MonthName { get; set; }

        public DateTime Date { get; private set; }

        public DayOfWeek DayOfWeek { get; set; }

        public bool IsDisabled { get; set; }
        
        public bool IsReadonly { get; set; }

        public CalenderViewItem(int day, bool isDisabled, DayOfWeek dayOfWeek, int month, int year, string monthName, bool isReadonly)
        {
            Day = day;
            IsDisabled = isDisabled;
            DayOfWeek = dayOfWeek;
            Month = month;
            Year = year;
            MonthName = monthName;
            IsReadonly = isReadonly;
            Date = new DateTime(year, month, day);
        }
    }
}
