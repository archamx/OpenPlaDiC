using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaDiC.WebPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class StartupCoreData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocal",
                table: "PickListValue",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocal",
                table: "PickList",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocal",
                table: "ObjectProperty",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocal",
                table: "Object",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocal",
                table: "PickListValue");

            migrationBuilder.DropColumn(
                name: "IsLocal",
                table: "PickList");

            migrationBuilder.DropColumn(
                name: "IsLocal",
                table: "ObjectProperty");

            migrationBuilder.DropColumn(
                name: "IsLocal",
                table: "Object");
        }
    }
}
