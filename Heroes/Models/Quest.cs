using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;

public class Quest
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public bool Complete {get; set;}
    public List<Hero> Heroes {get; set;}
}