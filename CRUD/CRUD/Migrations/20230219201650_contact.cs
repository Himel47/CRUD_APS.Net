using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemember",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemember",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
