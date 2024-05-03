using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;
namespace MvcMovie.Models;

public class Field 
{
    public int Id {get; set;}
    public string? Name {get; set;}


    public int CategoryId {get; set;}
    public Category? Category {get; set;}

    public IEnumerable<FieldValue>? FieldValues {get; set;}

}



