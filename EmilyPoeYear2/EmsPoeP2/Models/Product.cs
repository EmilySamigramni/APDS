using System;
using System.Collections.Generic;

namespace EmsPoeP2.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public DateOnly? ProductionDate { get; set; }
}
