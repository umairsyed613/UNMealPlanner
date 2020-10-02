using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UNMealPlanner.Services
{
    public interface IGroceryListService
    {
        Task<List<GroceryList>> GetALlGroceriesList();

        Task<GroceryList> GetGroceryListById(string Id);

        Task UpsertGroceryList(GroceryList groceryList);

        Task RemoveGroceryList(string Id);

        Task ClearAllData();

    }
}
