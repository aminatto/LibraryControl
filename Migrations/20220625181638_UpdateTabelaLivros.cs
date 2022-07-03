using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class UpdateTabelaLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDelivered",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DateRented",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Livros");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Livros",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Livros");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelivered",
                table: "Livros",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRented",
                table: "Livros",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Livros",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
