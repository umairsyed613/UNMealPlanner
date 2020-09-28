using System.ComponentModel.DataAnnotations;
using UNMealPlanner.Types;

namespace UNMealPlanner.Models
{
    public class Meal
    {
        [Required]
        public MealType MealType { get; set; }
        
        [Required]
        public string DishName { get; set; }
        
        [Required]
        public int CaloriesCount { get; set; }
    }
}
