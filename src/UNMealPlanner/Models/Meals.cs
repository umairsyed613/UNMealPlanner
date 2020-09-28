using System;
using System.Collections.Generic;
using System.Linq;

namespace UNMealPlanner.Models
{
    public class Meals
    {
        public List<Meal> DayMeals { get; set; } = new List<Meal>();

        public DateTime DateTime { get; set; }

        public int GetTotalCalories()
        {
            return DayMeals!.Sum(s => s.CaloriesCount);
        }
    }
}
