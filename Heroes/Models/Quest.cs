using System.ComponentModel.DataAnnotations;
using Npgsql.Replication;

namespace Heroes.Models;

public class Quest
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public bool Complete {get; set;}
    public List<Hero> Heroes {get; set;}

    public List<Equipment> Bounty {get; set;}


    public void makeBountyItemsAvailable()
    {
        if (Complete && Bounty != null)
        {
            foreach (var equipment in Bounty)
            {
                equipment.Available = true;
            }
        }

    }
}