using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int parent_id {get; set;}

    // Define the inverse relationship using [InverseProperty]
    public IEnumerable<Product> Products { get; set; } // Navigation property
    public IEnumerable<Field> Fields { get; set; } // Navigation property

}


