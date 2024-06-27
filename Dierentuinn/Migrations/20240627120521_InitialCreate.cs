using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dierentuinn.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomSizes",
                columns: table => new
                {
                    CustomSizeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomSizes", x => x.CustomSizeId);
                });

            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Climate = table.Column<string>(type: "TEXT", nullable: false),
                    HabitatType = table.Column<string>(type: "TEXT", nullable: false),
                    SecurityLevel = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dierens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SizeCustomSizeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DietaryClass = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityPattern = table.Column<int>(type: "INTEGER", nullable: false),
                    Prey = table.Column<string>(type: "TEXT", nullable: false),
                    EnclosureId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpaceRequirement = table.Column<double>(type: "REAL", nullable: false),
                    SecurityRequirement = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dierens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dierens_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dierens_CustomSizes_SizeCustomSizeId",
                        column: x => x.SizeCustomSizeId,
                        principalTable: "CustomSizes",
                        principalColumn: "CustomSizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dierens_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dierens_CategoryId",
                table: "Dierens",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dierens_EnclosureId",
                table: "Dierens",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Dierens_SizeCustomSizeId",
                table: "Dierens",
                column: "SizeCustomSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dierens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CustomSizes");

            migrationBuilder.DropTable(
                name: "Enclosures");
        }
    }
}
