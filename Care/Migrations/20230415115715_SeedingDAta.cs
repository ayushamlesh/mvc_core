using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Care.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDAta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CatId", "CatName", "Price", "Quantity" },
                values: new object[] { "11", "k", 100, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: "11");
        }
    }
}
