using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Farmer
{
    public int FarmerID { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    // Navigation property
    public ICollection<Product> Products { get; set; }
}
