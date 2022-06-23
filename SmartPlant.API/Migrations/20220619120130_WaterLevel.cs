using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPlant.API.Migrations
{
    public partial class WaterLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WaterLevels",
                columns: new[] { "WaterLevelId", "DateTime", "Percentage", "PlantId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 1 },
                    { 2, new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 1 },
                    { 3, new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 1 },
                    { 4, new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 1 },
                    { 5, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1 },
                    { 6, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 1 },
                    { 7, new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 1 },
                    { 8, new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1 },
                    { 9, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 2 },
                    { 10, new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 2 },
                    { 11, new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 2 },
                    { 12, new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 2 },
                    { 13, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 2 },
                    { 14, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 2 },
                    { 15, new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 2 },
                    { 16, new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WaterLevels",
                keyColumn: "WaterLevelId",
                keyValue: 16);
        }
    }
}
