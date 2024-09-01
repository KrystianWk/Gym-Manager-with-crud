using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagerInfractracture.Migrations
{
    public partial class CreatedByIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "GymManager",
                type: "nvarchar(450)",
                nullable: true);

            // Drop the primary key constraint for AspNetUserTokens
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            // Alter the Name column in AspNetUserTokens
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Recreate the primary key constraint for AspNetUserTokens
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            // Drop the primary key constraint for AspNetUserLogins
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            // Alter the ProviderKey column in AspNetUserLogins
            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Alter the LoginProvider column in AspNetUserLogins
            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Recreate the primary key constraint for AspNetUserLogins
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "UserId", "LoginProvider", "ProviderKey" });

            // Create index and foreign key for GymManager
            migrationBuilder.CreateIndex(
                name: "IX_GymManager_CreatedById",
                table: "GymManager",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_GymManager_AspNetUsers_CreatedById",
                table: "GymManager",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymManager_AspNetUsers_CreatedById",
                table: "GymManager");

            migrationBuilder.DropIndex(
                name: "IX_GymManager_CreatedById",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "GymManager");

            // Drop the primary key constraint for AspNetUserLogins
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            // Revert the ProviderKey column in AspNetUserLogins
            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            // Revert the LoginProvider column in AspNetUserLogins
            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            // Recreate the primary key constraint for AspNetUserLogins
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "UserId", "LoginProvider", "ProviderKey" });

            // Drop the primary key constraint for AspNetUserTokens
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            // Revert the Name column in AspNetUserTokens
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            // Revert the LoginProvider column in AspNetUserTokens
            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            // Recreate the primary key constraint for AspNetUserTokens
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });
        }
    }
}