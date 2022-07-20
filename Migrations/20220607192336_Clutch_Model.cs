using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmegaParts.Migrations
{
    /// <inheritdoc />
    public partial class Clutch_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clutches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make_and_model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diam = table.Column<float>(type: "real", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clutches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clutches");
        }
    }
}
