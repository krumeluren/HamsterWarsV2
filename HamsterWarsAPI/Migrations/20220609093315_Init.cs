using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamsterWarsAPI.Migrations
{
    public partial class Init : Migration
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
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Games = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "Age", "FavFood", "Games", "ImgName", "Losses", "Loves", "Name", "Wins" },
                values: new object[,]
                {
                    { 1, 1, "Nuts", 0, "1.jpg", 0, "Running", "Hamster1", 0 },
                    { 2, 2, "Carrot", 0, "2.jpg", 0, "Sleeping", "Hamster2", 0 },
                    { 3, 3, "Lettuce", 0, "3.jpg", 0, "Climbing", "Hamster3", 0 },
                    { 4, 4, "Spinach", 0, "4.jpg", 0, "Digging", "Hamster4", 0 },
                    { 5, 5, "Banana", 0, "5.jpg", 0, "Jumping", "Hamster5", 0 },
                    { 6, 6, "Carrot", 0, "6.jpg", 0, "Running", "Hamster6", 0 }
                });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 9, 11, 33, 15, 203, DateTimeKind.Local).AddTicks(6542), 2 });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 2, 3, new DateTime(2022, 6, 9, 11, 33, 15, 203, DateTimeKind.Local).AddTicks(6584), 2 });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 3, 2, new DateTime(2022, 6, 9, 11, 33, 15, 203, DateTimeKind.Local).AddTicks(6586), 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_LoserHamsterId",
                table: "Battles",
                column: "LoserHamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_WinnerHamsterId",
                table: "Battles",
                column: "WinnerHamsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Hamsters");
        }
    }
}
