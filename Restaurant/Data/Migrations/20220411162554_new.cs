using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e55b4d6-1340-4b7c-b57f-7d752a3337b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5320d3e-26f8-4c5b-a429-638df6db882c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c4a3728-8af3-4f8b-88a8-f3eb729b58fd", "a347f773-a0b8-4d0b-b5ac-13ecc0062f6a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a842efd-b4d8-4b4e-8c61-ab52b06ccb65", "a59d9e37-c894-4420-8e96-9fc1b0b5f5f4", "Regular", "REGULAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a842efd-b4d8-4b4e-8c61-ab52b06ccb65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c4a3728-8af3-4f8b-88a8-f3eb729b58fd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e55b4d6-1340-4b7c-b57f-7d752a3337b1", "b5f0a240-b54a-4c4f-8228-fc5e51b5e8da", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5320d3e-26f8-4c5b-a429-638df6db882c", "2bafe03f-a701-4a09-b5c8-22d0bf136309", "Regular", "REGULAR" });
        }
    }
}
