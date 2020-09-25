using System;
using System.Collections.Generic;

namespace UNMealPlanner.Models
{
    public class Meals
    {
        public List<Meal> DayMeals { get; set; }
        public int TotalCalories { get; set; }
        public DateTime DateTime { get; set; }
    }
}
