using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNMealPlanner.Models
{
    public class Meals
    {
        public List<Meal> DayMeals { get; set; } = new List<Meal>();

        [Required]
        public DateTime DateTime { get; set; }

        public string Key { get; set; }

        public int GetTotalCalories()
        {
            return DayMeals!.Sum(s => s.CaloriesCount);
        }
    }
}
