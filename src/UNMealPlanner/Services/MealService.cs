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
        private static string _key = "A8D2DAD930EA4D039E5794627BE6BE4D";

        private readonly ILocalStorageService _localStorageService;

        public MealService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task UpsertMeals(Meals meals)
        {
            var data = await GetAllMealsData() ?? new List<Meals>();

            meals.Key = MakeMealsKey(meals.DateTime);

            await RemoveInternal(data, meals.Key);

            //var rr = data.FirstOrDefault(a => a.Key == meals.Key);
            //if (rr != null && data.Remove(rr))
            //{
            //    Console.WriteLine("Old Record has been removed");
            //}

            data.Add(meals);

            await UpsertMealsList(data);
        }

        public async Task RemoveMeals(Meals meals)
        {
            var data = await GetAllMealsData();

            if (data == null)
            {
                Console.WriteLine("No Data to remove");

                return;
            }

            var key = MakeMealsKey(meals.DateTime);

            await RemoveInternal(data, key);
        }

        private async Task RemoveInternal(List<Meals> data, string key)
        {
            var exists = data.FirstOrDefault(a => a.Key == key);

            if (exists == null)
            {
                Console.WriteLine("No Previous record found to remove!");

                return;
            }

            if (!data.Remove(exists))
            {
                throw new InvalidOperationException("Failed to Delete the previous record");
            }

            await UpsertMealsList(data);
            Console.WriteLine("The record has been removed!");
        }

        public async Task<Meals> GetMealsByDatetime(DateTime dateTime)
        {
            var data = await GetAllMealsData();

            if (data == null)
            {
                return null;
            }

            return data.FirstOrDefault(w => w.Key == MakeMealsKey(dateTime));
        }

        public async Task ClearAllData() => await _localStorageService.RemoveItemAsync(_key);

        private async Task<List<Meals>> GetAllMealsData() => await _localStorageService.GetItemAsync<List<Meals>>(_key);

        private async Task UpsertMealsList(List<Meals> allMealsData)
        {
            if (await _localStorageService.ContainKeyAsync(_key))
            {
                await _localStorageService.RemoveItemAsync(_key);
            }

            allMealsData = allMealsData.OrderBy(a => a.DateTime).ToList();

            await _localStorageService.SetItemAsync(_key, allMealsData);
        }

        private static string MakeMealsKey(DateTime dateTime) => $"{dateTime.Year};{dateTime.Month};{dateTime.Day}";
    }
}
