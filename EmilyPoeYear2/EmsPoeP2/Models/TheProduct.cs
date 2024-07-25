using System;
using System.Collections.Generic;

namespace EmsPoeP2.Models;

public partial class TheProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public int FarmerId { get; set; }
}
