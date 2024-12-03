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
    public EquipmentType EquipmentType {get; set;}
    public int EquipmentTypeId {get; set;}
    public int? HeroId {get; set;}
    public int QuestId {get; set;}
    public Quest Quest { get; set; }
    public bool Available {get; set;}
}