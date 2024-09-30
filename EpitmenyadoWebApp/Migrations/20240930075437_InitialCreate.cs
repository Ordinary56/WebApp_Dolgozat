using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpitmenyadoWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Epitmenyek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaxNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    StreetName = table.Column<string>(type: "TEXT", nullable: false),
                    StreetNum = table.Column<string>(type: "TEXT", nullable: false),
                    Line = table.Column<char>(type: "TEXT", nullable: false),
                    Area = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epitmenyek", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Epitmenyek");
        }
    }
}
