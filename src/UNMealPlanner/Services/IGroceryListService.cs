using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UNMealPlanner.Services
{
    public interface IGroceryListService
    {
        Task<List<GroceryList>> GetALlGroceriesList();

        Task UpsertGroceryList(GroceryList groceryList);

        Task RemoveGroceryList(Guid Id);

        Task ClearAllData();

    }
}
