using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class Recreate : Migration
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
                    HeroClassId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_HeroClasses_HeroClassId",
                        column: x => x.HeroClassId,
                        principalTable: "HeroClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EquipmentTypeId = table.Column<int>(type: "integer", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: true),
                    QuestId = table.Column<int>(type: "integer", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipments_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroQuest",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    QuestId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroQuest", x => new { x.HeroId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_HeroQuest_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroQuest_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Available", "Description", "EquipmentTypeId", "HeroId", "Name", "QuestId", "Weight" },
                values: new object[,]
                {
                    { 1, false, "A legendary sword said to be unbreakable and capable of cutting through any material.", 1, null, "Excalibur", 2, 4.5 },
                    { 2, false, "Armor forged from the scales of an ancient dragon, providing unmatched durability.", 2, null, "Dragon Scale Armor", 2, 15.0 },
                    { 3, false, "A shield imbued with divine power to repel even the fiercest attacks.", 3, null, "Aegis", 3, 6.0 },
                    { 4, false, "A helmet that grants the wearer heightened perception and clarity of thought.", 4, null, "Helm of Insight", 3, 3.0 },
                    { 5, false, "Lightweight boots that allow the wearer to move with incredible speed.", 5, null, "Boots of Swiftness", 3, 2.0 },
                    { 6, false, "Gauntlets that grant the wearer immense physical power.", 6, null, "Gauntlets of Strength", 4, 5.0 },
                    { 7, false, "A mystical ring that slows the effects of aging and enhances magical abilities.", 7, null, "Ring of Eternity", 4, 0.10000000000000001 },
                    { 8, false, "An enchanted amulet that creates a magical barrier around the wearer.", 8, null, "Amulet of Protection", 5, 0.5 },
                    { 9, false, "A potion that restores health and vitality when consumed.", 9, null, "Healing Potion", 5, 0.29999999999999999 },
                    { 10, false, "A magical scroll containing the spell to cast a devastating fireball.", 10, null, "Scroll of Fireball", 5, 0.20000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "Description", "HeroClassId", "Level", "Name" },
                values: new object[,]
                {
                    { 1, "A brave knight seeking redemption.", 1, 10, "Arthas" },
                    { 2, "A powerful mage wielding frost magic.", 2, 12, "Jaina" },
                    { 3, "A shaman connected to the elements.", 3, 15, "Thrall" },
                    { 4, "A skilled ranger turned dark.", 4, 20, "Sylvanas" },
                    { 5, "A demon hunter seeking vengeance.", 5, 25, "Illidan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_HeroId",
                table: "Equipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_QuestId",
                table: "Equipments",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_HeroClassId",
                table: "Heroes",
                column: "HeroClassId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroQuest_QuestId",
                table: "HeroQuest",
                column: "QuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "HeroQuest");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "HeroClasses");
        }
    }
}
