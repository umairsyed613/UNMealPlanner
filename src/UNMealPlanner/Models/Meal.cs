using System;
using System.ComponentModel.DataAnnotations;
using UNMealPlanner.Types;

namespace UNMealPlanner.Models
{
    public class Meal
    {
        private Guid _id;

        [Required]
        public Guid Id
        {
            get => _id;
            private set
            {
                _id = Guid.NewGuid();
            }
        }

        [Required] public MealType MealType { get; set; }

        [Required] public string DishName { get; set; }

        [Required] public int CaloriesCount { get; set; }
    }
}
