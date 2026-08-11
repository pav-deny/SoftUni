using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _02.CodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class TitleReturned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Replies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "The tittle of the reply");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Replies");
        }
    }
}
