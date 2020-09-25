using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using UNMealPlanner.Models;

namespace UNMealPlanner.Services
{
    public class MealService : IMealService
    {
        private readonly ILocalStorageService _localStorageService;

        public MealService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task RegisterMeals(Meals meals)
        {
            var key = MakeKey(meals.DateTime);

            if (await _localStorageService.ContainKeyAsync(key))
            {
                return;
            }

            await _localStorageService.SetItemAsync<Meals>(key, meals);
        }

        public async Task<Meals> GetMealsByDatetime(DateTime dateTime)
        {
            var key = MakeKey(dateTime);

            if (await _localStorageService.ContainKeyAsync(key))
            {
                return await _localStorageService.GetItemAsync<Meals>(key);
            }

            return null;
        }

        private static string MakeKey(DateTime dateTime) => $"{dateTime.Year};{dateTime.Month};{dateTime.Day}";
    }
}