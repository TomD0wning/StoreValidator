using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreValidator.Migrations
{
    public partial class InitialSqlDockerCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Concessions",
                table: "Stores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Stores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concessions",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Stores");
        }
    }
}
