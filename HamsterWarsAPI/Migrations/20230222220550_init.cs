using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FavFood = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Loves = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImgName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: true),
                    Losses = table.Column<int>(type: "int", nullable: true),
                    Games = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfPost = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfPost = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerHamsterId = table.Column<int>(type: "int", nullable: true),
                    LoserHamsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Hamsters_LoserHamsterId",
                        column: x => x.LoserHamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Battles_Hamsters_WinnerHamsterId",
                        column: x => x.WinnerHamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantPlantCategory",
                columns: table => new
                {
                    PlantCategoriesId = table.Column<int>(type: "int", nullable: false),
                    PlantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantPlantCategory", x => new { x.PlantCategoriesId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_PlantPlantCategory_PlantCategories_PlantCategoriesId",
                        column: x => x.PlantCategoriesId,
                        principalTable: "PlantCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantPlantCategory_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "Age", "FavFood", "Games", "ImgName", "Losses", "Loves", "Name", "Wins" },
                values: new object[,]
                {
                    { 1, 1, "Food1", 0, "hamster-1.jpg", 0, "Loves1", "Hamster1", 0 },
                    { 2, 2, "Food2", 0, "hamster-2.jpg", 0, "Loves2", "Hamster2", 0 },
                    { 3, 3, "Food3", 0, "hamster-3.jpg", 0, "Loves3", "Hamster3", 0 },
                    { 4, 4, "Food4", 0, "hamster-4.jpg", 0, "Loves4", "Hamster4", 0 },
                    { 5, 5, "Food5", 0, "hamster-5.jpg", 0, "Loves5", "Hamster5", 0 },
                    { 6, 6, "Food6", 0, "hamster-6.jpg", 0, "Loves6", "Hamster6", 0 }
                });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 1, 1, new DateTime(2023, 2, 22, 23, 5, 50, 466, DateTimeKind.Local).AddTicks(1028), 2 });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 2, 3, new DateTime(2023, 2, 22, 23, 5, 50, 466, DateTimeKind.Local).AddTicks(1067), 2 });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 3, 2, new DateTime(2023, 2, 22, 23, 5, 50, 466, DateTimeKind.Local).AddTicks(1069), 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_LoserHamsterId",
                table: "Battles",
                column: "LoserHamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_WinnerHamsterId",
                table: "Battles",
                column: "WinnerHamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantPlantCategory_PlantsId",
                table: "PlantPlantCategory",
                column: "PlantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "PlantPlantCategory");

            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "PlantCategories");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
