using System;
using System.Collections.Generic;

namespace EmsFinalPoe.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public int FarmerId { get; set; }

    public virtual Farmer Farmer { get; set; } = null!;
}
