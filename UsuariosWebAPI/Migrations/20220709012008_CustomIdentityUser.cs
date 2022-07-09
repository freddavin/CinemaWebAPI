using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosWebAPI.Migrations
{
    public partial class CustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "3224e5f1-c60b-4bb0-83eb-51a6ea0fc7a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "728984d2-7a3d-4074-a198-e4dea0006b1b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f27a549b-5a49-4f9c-a5d8-de69d96aa92b", "AQAAAAEAACcQAAAAED03yO4bj7vc+xWIXsfXxwM9JPWVbCChmbzYJ0cBs6fT3yg78vcRV0uwa8YnJEivKQ==", "7c5389e5-16fc-4569-9dea-49433bbeef62" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "44afca91-148e-4378-bcab-b1b08dac249c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "aa48e13e-1604-41e3-9fca-289da48f4d60");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a18ded9-023a-4e37-bff6-08ce074c14b2", "AQAAAAEAACcQAAAAEAdvN7+mi3zeJ5aeWg0kZFxRSz7PdX5KFcsdaHbK99349SqAv6YwUes+kI7gpe3Q5A==", "b26b8e60-efed-44b4-9e13-3a6dc4ac055a" });
        }
    }
}
