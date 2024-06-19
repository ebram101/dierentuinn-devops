using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dierentuinn.Migrations
{
    /// <inheritdoc />
    public partial class Dieren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dieren",
                table: "Dieren");

            migrationBuilder.DropColumn(
                name: "category",
                table: "Dieren");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Dieren");

            migrationBuilder.RenameTable(
                name: "Dieren",
                newName: "Dierens");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dierens",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dierens",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityPattern",
                table: "Dierens",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dierens",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Dierens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DietaryClass",
                table: "Dierens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnclosureId",
                table: "Dierens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Prey",
                table: "Dierens",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SecurityRequirement",
                table: "Dierens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeCustomSizeId",
                table: "Dierens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SpaceRequirement",
                table: "Dierens",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Dierens",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dierens",
                table: "Dierens",
                column: "Id");

            migrationBuilder.CreateTable(
        name: "Dieren",
        columns: table => new
        {
            Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(type: "TEXT", nullable: false),
            Description = table.Column<string>(type: "TEXT", nullable: false),
            category = table.Column<string>(type: "TEXT", nullable: false),
            size = table.Column<string>(type: "TEXT", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Dieren", x => x.Id);
        });
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
                name: "CustomSize",
                columns: table => new
                {
                    CustomSizeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomSize", x => x.CustomSizeId);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Dierens_Categories_CategoryId",
                table: "Dierens",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dierens_CustomSize_SizeCustomSizeId",
                table: "Dierens",
                column: "SizeCustomSizeId",
                principalTable: "CustomSize",
                principalColumn: "CustomSizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dierens_Enclosures_EnclosureId",
                table: "Dierens",
                column: "EnclosureId",
                principalTable: "Enclosures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dierens_Categories_CategoryId",
                table: "Dierens");

            migrationBuilder.DropForeignKey(
                name: "FK_Dierens_CustomSize_SizeCustomSizeId",
                table: "Dierens");

            migrationBuilder.DropForeignKey(
                name: "FK_Dierens_Enclosures_EnclosureId",
                table: "Dierens");

            migrationBuilder.DropTable(
                name: "Dieren");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CustomSize");

            migrationBuilder.DropTable(
                name: "Enclosures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dierens",
                table: "Dierens");

            migrationBuilder.DropIndex(
                name: "IX_Dierens_CategoryId",
                table: "Dierens");

            migrationBuilder.DropIndex(
                name: "IX_Dierens_EnclosureId",
                table: "Dierens");

            migrationBuilder.DropIndex(
                name: "IX_Dierens_SizeCustomSizeId",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "DietaryClass",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "EnclosureId",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "Prey",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "SecurityRequirement",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "SizeCustomSizeId",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "SpaceRequirement",
                table: "Dierens");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Dierens");

            migrationBuilder.RenameTable(
                name: "Dierens",
                newName: "Dieren");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dieren",
                type: "TEXT",   
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dieren",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityPattern",
                table: "Dieren",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dieren",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Dieren",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Dieren",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dieren",
                table: "Dieren",
                column: "Id");
        }
    }
}
