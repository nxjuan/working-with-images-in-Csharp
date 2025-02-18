using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pinterestapi.Migrations
{
    /// <inheritdoc />
    public partial class _2thaddattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Posts",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Posts",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Posts");
        }
    }
}
