using System;
using System.ComponentModel.DataAnnotations;

public class GroceryItem
{
    public string Key { get; set; } = Guid.NewGuid().ToString("N");

    [Required] public string Name { get; set; }

    [Required] public string Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCompleted { get; set; }
}
