using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreValidator.Migrations
{
    public partial class DeptTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Stores");

            migrationBuilder.CreateTable(
                name: "StoreDepts",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    DepDescription = table.Column<string>(nullable: true),
                    DepSize = table.Column<long>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreDepts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreDepts_StoreId",
                table: "StoreDepts",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreDepts");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Stores",
                nullable: false,
                defaultValue: 0);
        }
    }
}
