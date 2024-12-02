using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Complete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    QuestId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EquipmentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Weapon" },
                    { 2, "Armor" },
                    { 3, "Shield" },
                    { 4, "Helmet" },
                    { 5, "Boots" },
                    { 6, "Gloves" },
                    { 7, "Ring" },
                    { 8, "Amulet" },
                    { 9, "Potion" },
                    { 10, "Scroll" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "HeroId", "Name", "TypeId", "Weight" },
                values: new object[,]
                {
                    { 1, "A legendary sword said to be unbreakable and capable of cutting through any material.", null, "Excalibur", 1, 4.5 },
                    { 2, "Armor forged from the scales of an ancient dragon, providing unmatched durability.", null, "Dragon Scale Armor", 2, 15.0 },
                    { 3, "A shield imbued with divine power to repel even the fiercest attacks.", null, "Aegis", 3, 6.0 },
                    { 4, "A helmet that grants the wearer heightened perception and clarity of thought.", null, "Helm of Insight", 4, 3.0 },
                    { 5, "Lightweight boots that allow the wearer to move with incredible speed.", null, "Boots of Swiftness", 5, 2.0 },
                    { 6, "Gauntlets that grant the wearer immense physical power.", null, "Gauntlets of Strength", 6, 5.0 },
                    { 7, "A mystical ring that slows the effects of aging and enhances magical abilities.", null, "Ring of Eternity", 7, 0.10000000000000001 },
                    { 8, "An enchanted amulet that creates a magical barrier around the wearer.", null, "Amulet of Protection", 8, 0.5 },
                    { 9, "A potion that restores health and vitality when consumed.", null, "Healing Potion", 9, 0.29999999999999999 },
                    { 10, "A magical scroll containing the spell to cast a devastating fireball.", null, "Scroll of Fireball", 10, 0.20000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "HeroClasses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Paladin" },
                    { 2, "Ranger" },
                    { 3, "Sorcerer" },
                    { 4, "Rogue" },
                    { 5, "Barbarian" }
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "ClassId", "Description", "Level", "Name", "QuestId" },
                values: new object[,]
                {
                    { 1, 1, "A brave knight seeking redemption.", 10, "Arthas", null },
                    { 2, 2, "A powerful mage wielding frost magic.", 12, "Jaina", null },
                    { 3, 3, "A shaman connected to the elements.", 15, "Thrall", null },
                    { 4, 4, "A skilled ranger turned dark.", 20, "Sylvanas", null },
                    { 5, 5, "A demon hunter seeking vengeance.", 25, "Illidan", null }
                });

            migrationBuilder.InsertData(
                table: "Quests",
                columns: new[] { "Id", "Complete", "Description", "Name" },
                values: new object[,]
                {
                    { 1, false, "The princess has been captured by the dark sorcerer. Travel to the enchanted castle and bring her back safely.", "Rescue the Princess" },
                    { 2, false, "A ferocious dragon has been terrorizing the nearby villages. Slay the beast to restore peace.", "Defeat the Dragon" },
                    { 3, false, "The ancient artifact has been stolen by a band of thieves. Recover it from their hidden lair.", "Retrieve the Lost Artifact" },
                    { 4, false, "Few have ventured into the Forbidden Forest and returned. Uncover its secrets and report back.", "Explore the Forbidden Forest" },
                    { 5, false, "Ensure the caravan reaches its destination safely through treacherous territory.", "Escort the Caravan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_HeroId",
                table: "Equipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_QuestId",
                table: "Heroes",
                column: "QuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "HeroClasses");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Quests");
        }
    }
}
