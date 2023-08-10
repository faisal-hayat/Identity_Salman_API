using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityWebApi.Migrations
{
    /// <inheritdoc />
    public partial class seedroleshasbeenaddedindbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c8b8356-e89c-4227-b922-77fc7cef4ff3", "3", "HR", "HR" },
                    { "325d7d1d-d17d-4d2d-9f98-45f91f1acf24", "1", "Admin", "Admin" },
                    { "ba28f8ca-0c54-4f8b-a561-8f057958fd68", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c8b8356-e89c-4227-b922-77fc7cef4ff3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "325d7d1d-d17d-4d2d-9f98-45f91f1acf24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba28f8ca-0c54-4f8b-a561-8f057958fd68");
        }
    }
}
