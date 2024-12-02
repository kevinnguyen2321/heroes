using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;

public class HeroClass
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}