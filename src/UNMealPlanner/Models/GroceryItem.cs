using System;
using System.ComponentModel.DataAnnotations;

public class GroceryItem
{
    [Required] public Guid Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCompleted { get; set; }
}
