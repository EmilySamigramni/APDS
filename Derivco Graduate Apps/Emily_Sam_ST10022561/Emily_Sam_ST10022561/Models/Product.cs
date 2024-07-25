using System;
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductID { get; set; }

    // Foreign key to Farmer
    public int FarmerID { get; set; }

    [Required]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; }

    public string Category { get; set; }

    [Display(Name = "Production Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? ProductionDate { get; set; }

    public string Description { get; set; }

    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Available Quantity")]
    public int AvailableQuantity { get; set; }

    // Navigation property
    public Farmer Farmer { get; set; }
}
