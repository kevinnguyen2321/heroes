namespace Heroes.Models.DTOs;

public class HeroDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ClassId { get; set; }
    public int Level { get; set; }
    public int QuestId { get; set; }
    public List<Equipment> Equipments { get; set; }
    
}