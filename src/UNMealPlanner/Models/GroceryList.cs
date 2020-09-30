
using System;
using System.Collections.Generic;

public class GroceryList
{
    public string Name { get; set; }

    public List<GroceryItem> Items { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCompleted { get; set; }

    public GroceryList()
    {
        Items = new List<GroceryItem>();
    }

    public void AddItem(GroceryItem item)
    {
        if (Items == null)
        {
            throw new InvalidOperationException("Cannot add item to null list");
        }

        Items.Add(item);
    }

}