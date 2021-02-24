using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class GroceryList
{
    public string Key { get; set; } = Guid.NewGuid().ToString("N");

    [Required] public string Name { get; set; }

    public string Description { get; set; }

    [Required] public List<GroceryItem> Items { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCompleted { get; set; }

    public decimal MoneySpent { get; set; } = 0m;
    
    public List<string> Receipts { get; set; }

    public GroceryList()
    {
        Items = new List<GroceryItem>();
    }

    public void AddItem(GroceryItem item)
    {
        if (Items == null) { throw new InvalidOperationException("Cannot add item to null list"); }

        Items.Add(item);
    }

    public int GetTodayDays()
    {
        return Math.Abs(Convert.ToInt32((CreatedAt - DateTime.Now).TotalDays));
    }
}
