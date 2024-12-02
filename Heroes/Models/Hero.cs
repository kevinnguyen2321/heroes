using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;

public class Hero
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    public HeroClass HeroClass { get; set; }
    public int HeroClassId { get; set; }
    public int Level { get; set; }
    public Quest Quest { get; set; }
    public int? QuestId { get; set; }
    public List<Equipment> Equipments { get; set; }
    
}