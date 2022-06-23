using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPlant.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "MaxMoistureLevel", "MaxWaterLevel", "MinMoistureLevel", "MinWaterLevel", "Name" },
                values: new object[,]
                {
                    { 1, 0, 0, 0, 0, "Alocasia" },
                    { 2, 0, 0, 0, 0, "Bonsai" },
                    { 3, 0, 0, 0, 0, "Cactus" },
                    { 4, 0, 0, 0, 0, "Palmboom" }
                });

            migrationBuilder.InsertData(
                table: "Moistures",
                columns: new[] { "MoistureId", "DateTime", "Percentage", "PlantId" },
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
                    { 9, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 2 },
                    { 10, new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 2 },
                    { 11, new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 2 },
                    { 12, new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 2 },
                    { 13, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2 },
                    { 14, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 2 },
                    { 15, new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 2 },
                    { 16, new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Moistures",
                keyColumn: "MoistureId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2);
        }
    }
}
