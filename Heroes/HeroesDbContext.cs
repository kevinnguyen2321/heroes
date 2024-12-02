using Microsoft.EntityFrameworkCore;
using Heroes.Models;

public class HeroesDbContext : DbContext
{

    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmentType> EquipmentTypes { get; set; }
    public DbSet<HeroClass> HeroClasses { get; set; }
    public DbSet<Quest> Quests { get; set; }

    public HeroesDbContext(DbContextOptions<HeroesDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
  
    modelBuilder.Entity<Hero>().HasData(new Hero[]
    {
        new Hero { Id = 1, Name = "Arthas", Description = "A brave knight seeking redemption.", HeroClassId = 1, Level = 10, QuestId = 1},
        new Hero { Id = 2, Name = "Jaina", Description = "A powerful mage wielding frost magic.", HeroClassId = 2, Level = 12, QuestId = 1},
        new Hero { Id = 3, Name = "Thrall", Description = "A shaman connected to the elements.", HeroClassId = 3, Level = 15, QuestId = 4},
        new Hero { Id = 4, Name = "Sylvanas", Description = "A skilled ranger turned dark.", HeroClassId = 4, Level = 20, },
        new Hero { Id = 5, Name = "Illidan", Description = "A demon hunter seeking vengeance.", HeroClassId = 5, Level = 25, }
    });

    
    modelBuilder.Entity<Equipment>().HasData(new Equipment[]
    {
        new Equipment { Id = 1, Name = "Excalibur", Description = "A legendary sword said to be unbreakable and capable of cutting through any material.", Weight = 4.5, EquipmentTypeId = 1 },
        new Equipment { Id = 2, Name = "Dragon Scale Armor", Description = "Armor forged from the scales of an ancient dragon, providing unmatched durability.", Weight = 15.0, EquipmentTypeId = 2,  },
        new Equipment { Id = 3, Name = "Aegis", Description = "A shield imbued with divine power to repel even the fiercest attacks.", Weight = 6.0, EquipmentTypeId = 3,  },
        new Equipment { Id = 4, Name = "Helm of Insight", Description = "A helmet that grants the wearer heightened perception and clarity of thought.", Weight = 3.0, EquipmentTypeId = 4, },
        new Equipment { Id = 5, Name = "Boots of Swiftness", Description = "Lightweight boots that allow the wearer to move with incredible speed.", Weight = 2.0, EquipmentTypeId = 5, },
        new Equipment { Id = 6, Name = "Gauntlets of Strength", Description = "Gauntlets that grant the wearer immense physical power.", Weight = 5.0, EquipmentTypeId = 6, },
        new Equipment { Id = 7, Name = "Ring of Eternity", Description = "A mystical ring that slows the effects of aging and enhances magical abilities.", Weight = 0.1, EquipmentTypeId = 7, },
        new Equipment { Id = 8, Name = "Amulet of Protection", Description = "An enchanted amulet that creates a magical barrier around the wearer.", Weight = 0.5, EquipmentTypeId = 8, },
        new Equipment { Id = 9, Name = "Healing Potion", Description = "A potion that restores health and vitality when consumed.", Weight = 0.3, EquipmentTypeId = 9, },
        new Equipment { Id = 10, Name = "Scroll of Fireball", Description = "A magical scroll containing the spell to cast a devastating fireball.", Weight = 0.2, EquipmentTypeId = 10, }
    });

      modelBuilder.Entity<EquipmentType>().HasData(new EquipmentType[]
    {
        new EquipmentType { Id = 1, Name = "Weapon" },
        new EquipmentType { Id = 2, Name = "Armor" },
        new EquipmentType { Id = 3, Name = "Shield" },
        new EquipmentType { Id = 4, Name = "Helmet" },
        new EquipmentType { Id = 5, Name = "Boots" },
        new EquipmentType { Id = 6, Name = "Gloves" },
        new EquipmentType { Id = 7, Name = "Ring" },
        new EquipmentType { Id = 8, Name = "Amulet" },
        new EquipmentType { Id = 9, Name = "Potion" },
        new EquipmentType { Id = 10, Name = "Scroll" }
    });

      modelBuilder.Entity<HeroClass>().HasData(new HeroClass[]
    {
        new HeroClass { Id = 1, Name = "Paladin"},
        new HeroClass { Id = 2, Name = "Ranger"},
        new HeroClass { Id = 3, Name = "Sorcerer"},
        new HeroClass { Id = 4, Name = "Rogue"},
        new HeroClass { Id = 5, Name = "Barbarian"}
    });

      modelBuilder.Entity<Quest>().HasData(new Quest[]
    {
        new Quest { Id = 1, Name = "Rescue the Princess", Description = "The princess has been captured by the dark sorcerer. Travel to the enchanted castle and bring her back safely.", Complete = false },
        new Quest { Id = 2, Name = "Defeat the Dragon", Description = "A ferocious dragon has been terrorizing the nearby villages. Slay the beast to restore peace.", Complete = false },
        new Quest { Id = 3, Name = "Retrieve the Lost Artifact", Description = "The ancient artifact has been stolen by a band of thieves. Recover it from their hidden lair.", Complete = false },
        new Quest { Id = 4, Name = "Explore the Forbidden Forest", Description = "Few have ventured into the Forbidden Forest and returned. Uncover its secrets and report back.", Complete = false },
        new Quest { Id = 5, Name = "Escort the Caravan", Description = "Ensure the caravan reaches its destination safely through treacherous territory.", Complete = false } 
    });
}
}