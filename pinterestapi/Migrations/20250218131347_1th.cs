using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pinterestapi.Migrations
{
    /// <inheritdoc />
    public partial class _1th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "Posts",
                type: "character varying(10485760)",
                maxLength: 10485760,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "Posts");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Posts",
                type: "bytea",
                maxLength: 10485760,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
