using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;

public class Equipment
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public double Weight { get; set; }
    public int TypeId {get; set;}
    public int? HeroId {get; set;}
}