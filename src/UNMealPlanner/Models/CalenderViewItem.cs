namespace UNMealPlanner.Models
{
    public class CalenderViewItem
    {
        public int Day { get; set; }

        public bool IsDisabled { get; set; }

        public CalenderViewItem(int day, bool isDisabled)
        {
            Day = day;
            IsDisabled = isDisabled;
        }
    }
}
