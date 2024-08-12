using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagerInfractracture.Migrations
{
    /// <inheritdoc />
    public partial class encodedname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "GymManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "GymManager");
        }
    }
}
