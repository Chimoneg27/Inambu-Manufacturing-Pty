using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InambuManufacturingPty.Migrations
{
    /// <inheritdoc />
    public partial class AddProductionLines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLines", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductionLines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Production Line 1" },
                    { 2, "Production Line 2" },
                    { 3, "Production Line 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionLines");
        }
    }
}
