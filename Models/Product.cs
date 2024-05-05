using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Models;

public class Product
{
    [Key]
    public int? Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [DataType(DataType.Currency)]
    [Required]
    public decimal Price { get; set; }

    public IEnumerable<FieldValue>? FieldValues {get; set;}

    public string? ImageUrl { get; set; } // Add this line

    //public object Title { get; internal set; }
}