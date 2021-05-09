using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortLink.DataAccessLayer.Migrations
{
    public partial class MigCreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbShortLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortedLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbShortLinks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbShortLinks");
        }
    }
}
