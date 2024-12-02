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
builder.Services.AddNpgsql<HeroesDbContext>(builder.Configuration["HeroesDbConnectionString"]);


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
        .Include(h => h.Quest)
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
        Quest = foundHero.Quest != null ? new QuestDTO
        {
            Id = foundHero.Quest.Id,
            Name = foundHero.Quest.Name,
            Description = foundHero.Quest.Description,
            Complete = foundHero.Quest.Complete,
        } : null,
        Equipments = foundHero.Equipments
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
                Name = e.EquipmentType.Name
            }
        }).ToList();
});

app.MapGet("/quests", (HeroesDbContext db) => 
{
    return db.Quests
    .Select(q => new QuestDTO
    {
        Name = q.Name,
        Complete = q.Complete
    }).ToList();
});

app.MapGet("/quests/{id}", (HeroesDbContext db, int id) => 
{
    Quest foundQuest = db.Quests
    .Include(q => q.Heroes)
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
        }).ToList() ?? new List<HeroDTO>()
    });
});

app.MapPost("/quests", (HeroesDbContext db, Quest quest) => 
{
    db.Quests.Add(quest);
    db.SaveChanges();

    return Results.Created($"/quests/{quest.Id}", quest);
});

app.MapPut("/heroes/assign/{id}/{questId}", (HeroesDbContext db, int id, int questId) => {
    Hero foundHero = db.Heroes.FirstOrDefault(h => h.Id == id);

    if (foundHero == null)
    {
        return Results.NotFound();
    }

    foundHero.QuestId = questId;
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
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPost("/equipments/", (HeroesDbContext db, Equipment equipment) =>
{
    db.Equipments.Add(equipment);
    db.SaveChanges();

    return Results.Created($"/equipments/{equipment.Id}",equipment);
});






app.Run();


