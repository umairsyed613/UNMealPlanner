using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class GroceryList
{
    [Required] public Guid Id { get; set; }

    [Required] public string Name { get; set; }

    public string Description { get; set; }

    [Required] public List<GroceryItem> Items { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCompleted { get; set; }

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
        return Convert.ToInt32((CreatedAt - DateTime.Now).TotalDays);
    }
}
