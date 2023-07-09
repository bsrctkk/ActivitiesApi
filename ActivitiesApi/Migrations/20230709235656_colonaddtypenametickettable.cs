using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivitiesApi.Migrations
{
    public partial class colonaddtypenametickettable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Tickets");
        }
    }
}
