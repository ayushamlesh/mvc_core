using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Care.Migrations
{
    /// <inheritdoc />
    public partial class changedtablecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medecines");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "Medecines",
                columns: table => new
                {
                    BatchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecines", x => x.BatchId);
                });
        }
    }
}
