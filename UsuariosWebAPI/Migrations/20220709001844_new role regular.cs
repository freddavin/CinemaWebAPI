using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosWebAPI.Migrations
{
    public partial class newroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "aa48e13e-1604-41e3-9fca-289da48f4d60");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "44afca91-148e-4378-bcab-b1b08dac249c", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a18ded9-023a-4e37-bff6-08ce074c14b2", "AQAAAAEAACcQAAAAEAdvN7+mi3zeJ5aeWg0kZFxRSz7PdX5KFcsdaHbK99349SqAv6YwUes+kI7gpe3Q5A==", "b26b8e60-efed-44b4-9e13-3a6dc4ac055a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "571ca9cc-df1f-4042-81a3-342bf2a6e97e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da7bbd76-41f8-4991-b07d-3d97e14b271f", "AQAAAAEAACcQAAAAED2eoVofcFQTqUqRmEECwxlda6IEy2qXO7ujl+xM/cTBNRPjXqp3rpQGZY2Nlx48GA==", "62b3e13b-24d8-4e72-a3d2-e0461af86dd1" });
        }
    }
}
