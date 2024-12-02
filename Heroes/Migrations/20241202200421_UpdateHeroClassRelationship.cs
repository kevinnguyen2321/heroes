using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHeroClassRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Heroes",
                newName: "HeroClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_HeroClassId",
                table: "Heroes",
                column: "HeroClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_HeroClasses_HeroClassId",
                table: "Heroes",
                column: "HeroClassId",
                principalTable: "HeroClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_HeroClasses_HeroClassId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_HeroClassId",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "HeroClassId",
                table: "Heroes",
                newName: "ClassId");
        }
    }
}
