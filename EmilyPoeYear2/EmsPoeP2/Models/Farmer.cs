using System;
using System.Collections.Generic;

namespace EmsPoeP2.Models;

public partial class Farmer
{
    public int FarmerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? ContactInfo { get; set; }
}
