using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Models;


public class FieldValue 
{
    public int Id {get; set;}
    
    public string? Value {get; set;}

    public int ProductId {get; set;}
    public Product? Product {get; set;}

    public int FieldId {get; set;}
    public Field? Field {get; set;}
}