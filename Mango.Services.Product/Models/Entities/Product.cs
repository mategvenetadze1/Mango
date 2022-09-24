﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models.Entities;

public class Product : EntityBase
{
    [Required]
    public string Name { get; set; }
    [Range(1, 1000)]
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
}
