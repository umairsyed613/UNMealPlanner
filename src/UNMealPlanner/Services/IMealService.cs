using System;
using System.Threading.Tasks;
using UNMealPlanner.Models;

namespace UNMealPlanner.Services
{
    public interface IMealService
    {
        Task UpsertMeals(Meals meals);
        
        Task RemoveMeals(Meals meals);

        Task<Meals> GetMealsByDatetime(DateTime dateTime);

        Task ClearAllData();
    }
}
