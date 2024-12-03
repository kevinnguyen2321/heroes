using Heroes.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Heroes.Models.DTOs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
// builder.Services.AddNpgsql<HeroesDbContext>(builder.Configuration["HeroesDbConnectionString"]);

builder.Services.AddDbContext<HeroesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/heroes", (HeroesDbContext db)=> {
    return db.Heroes
    .Select(h => new HeroDTO
    {
       Name = h.Name,
       HeroClassId = h.HeroClassId,
    }
    ).ToList();

});

app.MapGet("/heroes/{id}", (HeroesDbContext db, int id) =>
{
    Hero? foundHero = db.Heroes
        .Include(h => h.HeroClass)
        .Include(h => h.Quests)
        .Include(h => h.Equipments)
        .FirstOrDefault(h => h.Id == id);

    if (foundHero == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new HeroDTO
    {
        Name = foundHero.Name,
        Description = foundHero.Description,
        HeroClass = foundHero.HeroClass != null ? new HeroClassDTO
        {
            Id = foundHero.HeroClass.Id,
            Name = foundHero.HeroClass.Name
        } : null,
        Level = foundHero.Level,
        Quests = foundHero.Quests != null ? foundHero.Quests.Select(q => new QuestDTO
        {
            Id = q.Id,
            Name = q.Name,
            Description = q.Description,
            Complete = q.Complete,
            Heroes = q.Heroes != null ? q.Heroes.Select(h => new HeroDTO
            {
                Name = h.Name
            }).ToList() : null
        }).ToList() : null
       
    });
});

app.MapGet("/equipments", (HeroesDbContext db) => 
{
   return  db.Equipments
        .Include(e => e.EquipmentType)
        .Select(e => new EquipmentDTO
        {
            Name = e.Name,
            Description = e.Description,
            EquipmentType = new EquipmentTypeDTO
            {
                Name = e.EquipmentType.Name,
                
            },
            Available = e.Available
            
        }).ToList();
});

app.MapGet("/quests", (HeroesDbContext db) => 
{
    return db.Quests
    .Select(q => new QuestDTO
    {
        Id = q.Id,
        Name = q.Name,
        Complete = q.Complete
    }).ToList();
});

app.MapGet("/quests/{id}", (HeroesDbContext db, int id) => 
{
     Quest foundQuest = db.Quests
        .Include(q => q.Heroes)
        .Include(q => q.Bounty) // Include the related Equipments
        .FirstOrDefault(q => q.Id == id);

    if (foundQuest == null)
    {
        return Results.NotFound(); 
    }

    return Results.Ok(new QuestDTO
    {
        Id = foundQuest.Id,
        Name = foundQuest.Name,
        Description = foundQuest.Description,
        Complete = foundQuest.Complete,
        Heroes = foundQuest.Heroes?.Select(h => new HeroDTO
        {
            Id = h.Id,
            Name = h.Name,
        }).ToList() ?? new List<HeroDTO>(),
        Bounty = foundQuest.Bounty?.Select(b => new EquipmentDTO
        {
            Name = b.Name,
            QuestId = b.QuestId,
            Available = b.Available
        }).ToList() ?? new List<EquipmentDTO>()

    });
});

app.MapPost("/quests", (HeroesDbContext db, Quest quest) => 
{
    db.Quests.Add(quest);
    db.SaveChanges();

    return Results.Created($"/quests/{quest.Id}", quest);
});

app.MapPut("/heroes/assign/{id}/{questId}", (HeroesDbContext db, int id, Quest quest) => {
    Hero foundHero = db.Heroes.FirstOrDefault(h => h.Id == id);

    if (foundHero == null)
    {
        return Results.NotFound();
    }
    foundHero.Quests = new List<Quest>();
    foundHero.Quests.Add(quest);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPut("/quests/complete/{questId}", (HeroesDbContext db, int questId) => {
    Quest foundQuest = db.Quests.FirstOrDefault(q => q.Id == questId);

    if (foundQuest == null)
    {
        return Results.NotFound();
    }

    foundQuest.Complete = true;
    foundQuest.Bounty = db.Equipments.Where(e => e.QuestId == questId).ToList();
    foundQuest.makeBountyItemsAvailable();
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPost("/equipments/", (HeroesDbContext db, Equipment equipment) =>
{
    db.Equipments.Add(equipment);
    db.SaveChanges();

    return Results.Created($"/equipments/{equipment.Id}",equipment);
});

app.MapPut("/heroes/assign-equipment/{id}", (HeroesDbContext db, int id, Equipment equipment) => {
    Hero foundHero = db.Heroes.FirstOrDefault(h => h.Id == id);
    if (foundHero == null)
    {
        return Results.NotFound();
    }

   foundHero.Equipments =  new List<Equipment>();
   foundHero.Equipments.Add(equipment);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapDelete("/equipments/{id}", (HeroesDbContext db, int id) => {
    Equipment foundEquipment = db.Equipments.FirstOrDefault(e => e.Id == id);
  if(foundEquipment == null)
  {
      return Results.NotFound();
  }
  db.Equipments.Remove(foundEquipment);
  db.SaveChanges();
  return Results.NoContent();
});


app.MapDelete("/heroes/{id}", (HeroesDbContext db, int id) => {
    Hero foundHero = db.Heroes.FirstOrDefault(h => h.Id == id);
  if(foundHero == null)
  {
      return Results.NotFound();
  }
  db.Heroes.Remove(foundHero);
  db.SaveChanges();
  return Results.NoContent();
});

app.MapDelete("/quests/{id}", (HeroesDbContext db, int id) => {
    Quest foundQuest = db.Quests.FirstOrDefault(q => q.Id == id);
  if(foundQuest == null)
  {
      return Results.NotFound();
  }
  db.Quests.Remove(foundQuest);
  db.SaveChanges();
  return Results.NoContent();
});




app.Run();


