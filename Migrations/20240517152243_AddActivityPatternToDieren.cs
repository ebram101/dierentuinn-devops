using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dierentuinn.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityPatternToDieren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityPattern",
                table: "Dieren",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityPattern",
                table: "Dieren");
        }
    }
}
