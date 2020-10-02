using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazored.LocalStorage;

namespace UNMealPlanner.Services
{
    public class GroceryListService : IGroceryListService
    {
        private static readonly string _key = "92C792370CFF4357BB6FE81EFD9C356D";

        private readonly ILocalStorageService _localStorageService;

        public GroceryListService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task ClearAllData() => await _localStorageService.RemoveItemAsync(_key);

        public async Task RemoveGroceryList(string Id)
        {
            if (await _localStorageService.ContainKeyAsync(_key))
            {
                var data = await _localStorageService.GetItemAsync<List<GroceryList>>(_key);

                if (data != null)
                {
                    var toRemove = data.FirstOrDefault(f => f.Key == Id);
                    data.Remove(toRemove);
                    await UpsertAllGroceryLists(data);
                }
            }
        }

        public async Task<List<GroceryList>> GetALlGroceriesList() => await _localStorageService.GetItemAsync<List<GroceryList>>(_key);

        public async Task<GroceryList> GetGroceryListById(string Id)
        {
            var data = await _localStorageService.GetItemAsync<List<GroceryList>>(_key);

            if (data == null)
            {
                return null;
            }

            return data.FirstOrDefault(f => f.Key == Id);
        }

        public async Task UpsertGroceryList(GroceryList groceryList)
        {
            Console.WriteLine(groceryList.Key);

            await RemoveGroceryList(groceryList.Key);

            var data = await GetALlGroceriesList();

            if (data != null)
            {
                data.Add(groceryList);
            }
            else
            {
                data = new List<GroceryList>
                {
                    groceryList
                };
            }

            await UpsertAllGroceryLists(data);
        }

        private async Task UpsertAllGroceryLists(List<GroceryList> data)
        {
            if (await _localStorageService.ContainKeyAsync(_key))
            {
                await _localStorageService.RemoveItemAsync(_key);
            }

            await _localStorageService.SetItemAsync(_key, data);
        }
    }
}
