using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagerInfractracture.Migrations
{
    /// <inheritdoc />
    public partial class Databasedevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GymManager",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "GymManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GymManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "GymManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsMembershipPaid",
                table: "GymManager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedAt",
                table: "GymManager",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "GymManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MembershipType",
                table: "GymManager",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "GymManager",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "IsMembershipPaid",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "JoinedAt",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "GymManager");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "GymManager");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "GymManager",
                newName: "Name");
        }
    }
}
