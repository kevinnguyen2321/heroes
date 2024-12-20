namespace Heroes.Models.DTOs;

public class EquipmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int EquipmentTypeId {get; set;}
    public EquipmentTypeDTO EquipmentType {get; set;} 
    public int HeroId {get; set;}
    public int QuestId {get; set;}
    public QuestDTO Quest { get; set; }
    public bool Available {get; set;}
}