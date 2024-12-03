namespace Heroes.Models.DTOs;

public class QuestDTO
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public bool Complete {get; set;}
    public List<HeroDTO> Heroes {get; set;}
      public List<EquipmentDTO> Bounty {get; set;}
}