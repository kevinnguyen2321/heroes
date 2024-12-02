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
    return db.Quests.Include()
});




app.Run();


