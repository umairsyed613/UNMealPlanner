using UNMealPlanner.Types;

namespace UNMealPlanner.Models
{
    public class Meal
    {
        public MealType MealType { get; set; }
        public string DishName { get; set; }
        public int CaloriesCount { get; set; }
    }
}
