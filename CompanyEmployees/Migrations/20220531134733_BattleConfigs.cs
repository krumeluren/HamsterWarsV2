using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamsterWars.Migrations
{
    public partial class BattleConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 1, 1, DateTime.Now, 2 });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 2, 3, DateTime.Now, 2 });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "LoserHamsterId", "TimeOfPost", "WinnerHamsterId" },
                values: new object[] { 3, 2, DateTime.Now, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
