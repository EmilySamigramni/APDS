using System;
using System.Collections.Generic;

namespace TheAgriApp.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int FarmerId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Category { get; set; }

    public DateOnly? ProductionDate { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int AvailableQuantity { get; set; }

    public virtual Farmer Farmer { get; set; } = null!;
}
