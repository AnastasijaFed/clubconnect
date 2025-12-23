using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Clubs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Clubs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clubs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clubs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Clubs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Clubs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Clubs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clubs");
        }
    }
}
