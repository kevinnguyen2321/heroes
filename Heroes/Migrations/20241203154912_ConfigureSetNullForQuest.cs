using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureSetNullForQuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Quests_QuestId",
                table: "Heroes");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Quests_QuestId",
                table: "Heroes",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Quests_QuestId",
                table: "Heroes");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Quests_QuestId",
                table: "Heroes",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");
        }
    }
}
