using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShipBase.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string? Category { get; set; } = null;

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a product brand")]
        public string? Brand { get; set; } = null;

        [Required(ErrorMessage = "Please enter a description")]
        public string? Description { get; set; } = null;
        public string? ImageURL { get; set; } = null;
        public string? AttributeName { get; set; } = null;
        public string? AttributeNameValue { get; set; } = null;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive weight")]
        public float? Weight { get; set; } = 0.0f;
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive length")]
        public float? Length { get; set; } = 0.0f;
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive width")]
        public float? Width { get; set; } = 0.0f;
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive height")]
        public float? Height { get; set; } = 0.0f;
        
        public int Amount { get; set; } = 0;

        public IEnumerable<Review>? Reviews { get; set; }


        
        
    }
}

