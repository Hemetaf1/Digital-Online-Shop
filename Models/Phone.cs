using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Models;

public class Phone
{
    
    public int Id { get; set; }

   // [Display(Name = "نام")]

    [StringLength(60, MinimumLength = 10)]
    [Required]
    public string? Name { get; set; }
    //[DataType(DataType.Date)]
    [StringLength(60, MinimumLength = 4)]

    public string? Description { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Color { get; set; }


    [DataType(DataType.Currency)]
    //[Column(TypeName = "decimal(18, 2)")]
    [Required]

    public decimal Price { get; set; }

   public string? ImageUrl { get; set; }

    //public object Title { get; internal set; }
}


/*
public struct LimitedDecimal
{
    private decimal value;

    public LimitedDecimal(decimal value)
    {
        this.value = Math.Round(value, 2); // Round to 2 decimal places
    }

    public static implicit operator LimitedDecimal(int v)
    {
        throw new NotImplementedException();
    }

}
*/
