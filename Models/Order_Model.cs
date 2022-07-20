using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
namespace OmegaParts.Models;

public class Order_Model
{
    public int Id { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z\s]*$")]
    public string? Name { get; set; }
    [Required]
    [RegularExpression(@"^[0-9]*$")]
    public string? Number { get; set; }
    [Required]
    public string? Address { get; set; }
    public string? Order { get; set; }
}