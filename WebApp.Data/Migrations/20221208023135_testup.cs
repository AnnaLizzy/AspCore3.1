using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class testup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(nullable: false),
                    CardNumber = table.Column<string>(maxLength: 200, nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ControlType = table.Column<int>(nullable: false),
                    WorkType = table.Column<int>(nullable: false),
                    CardModelID = table.Column<int>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    CardGUID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "edd39ffe-11f5-47e3-a487-3ef9e9f8f408");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6611f422-d46f-4c4e-ad3b-2eca6b77329c", "AQAAAAEAACcQAAAAED064t6l3bwAOsKDMONP78E/uHPXxuvQdr06qAvs53vbW65dGKc3MDvspsGGwrpmFQ==" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 8, 9, 31, 34, 710, DateTimeKind.Local).AddTicks(878));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "39e0fb91-7a0b-4c14-b026-014c932b6134");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd190371-ab6f-4ac9-9078-cedd8b8603ab", "AQAAAAEAACcQAAAAEA2tiAFqLOOftHQNkyEo7hVMd0hlrxmhKFdvjXCrNp4pJw/Ic300as2Ic2fCwgRO4g==" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 8, 9, 23, 15, 953, DateTimeKind.Local).AddTicks(9977));
        }
    }
}
