using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyHeroesQuests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Quests_QuestId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_QuestId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "QuestId",
                table: "Heroes");

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

            migrationBuilder.CreateIndex(
                name: "IX_HeroQuest_QuestId",
                table: "HeroQuest",
                column: "QuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroQuest");

            migrationBuilder.AddColumn<int>(
                name: "QuestId",
                table: "Heroes",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 4,
                column: "QuestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 5,
                column: "QuestId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_QuestId",
                table: "Heroes",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Quests_QuestId",
                table: "Heroes",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
