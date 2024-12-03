namespace Heroes.Models.DTOs;

public class HeroDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public HeroClassDTO HeroClass { get; set; }
    public int HeroClassId { get; set; }
    public int Level { get; set; }
    public List<QuestDTO> Quests { get; set; }
    public List<EquipmentDTO> Equipments { get; set; }
    
}