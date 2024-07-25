using System;
using System.Collections.Generic;

namespace EmsFinalPoe.Models;

public partial class Farmer
{
    public int FarmerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
