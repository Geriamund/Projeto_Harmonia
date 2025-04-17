using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Harmonia.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableFamily : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Membros",
                table: "Families");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Membros",
                table: "Families",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
