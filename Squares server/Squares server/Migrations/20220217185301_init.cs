using Microsoft.EntityFrameworkCore.Migrations;

namespace Squares_server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NamedLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamedLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    xCoord = table.Column<int>(type: "int", nullable: false),
                    yCoord = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NamedListPoints",
                columns: table => new
                {
                    NamedListId = table.Column<int>(type: "int", nullable: false),
                    PointModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamedListPoints", x => new { x.NamedListId, x.PointModelId });
                    table.ForeignKey(
                        name: "FK_NamedListPoints_NamedLists_NamedListId",
                        column: x => x.NamedListId,
                        principalTable: "NamedLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NamedListPoints_Points_PointModelId",
                        column: x => x.PointModelId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NamedListPoints_PointModelId",
                table: "NamedListPoints",
                column: "PointModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NamedListPoints");

            migrationBuilder.DropTable(
                name: "NamedLists");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
