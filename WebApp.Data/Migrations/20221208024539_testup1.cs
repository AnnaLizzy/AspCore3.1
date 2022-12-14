using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class testup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c92370c6-5d3f-418c-a1f2-11439295a327");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56c9ea9f-ed7a-4731-a00e-4a21d47d0151", "AQAAAAEAACcQAAAAEPrePf5aoAZMoAv6L+1yQQIpeYaS4TbujqAcYQFNlda7tkkw7rZ3fUbNX4uKZVDNrg==" });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "CardID", "AdminID", "CardGUID", "CardModelID", "CardNumber", "Color", "Company", "ControlType", "CreatedTime", "DeleteDate", "EndTime", "ID", "IsDeleted", "ModifiedTime", "SerialNumber", "Status", "Type", "WorkType" },
                values: new object[] { 2, 2, 0, 0, "M201911-05-QV", 0, "Viet quang.,ltd", 2, new DateTime(2022, 12, 8, 9, 45, 38, 730, DateTimeKind.Local).AddTicks(6987), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2100027", 1, 3, 1 });

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
                value: new DateTime(2022, 12, 8, 9, 45, 38, 733, DateTimeKind.Local).AddTicks(3894));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Card",
                keyColumn: "CardID",
                keyValue: 2);

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
    }
}
