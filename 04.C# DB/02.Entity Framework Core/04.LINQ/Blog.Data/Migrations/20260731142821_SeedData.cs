using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Jhon Doe" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, 1, "idk man", "First Post" },
                    { 2, 1, "idk man, again", "Second Post" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "PostId", "Title" },
                values: new object[,]
                {
                    { 1, "Good one", 1, "Idk" },
                    { 2, "Still good...", 1, "Idk 2: Electric boogalo" },
                    { 3, "Cause why not", 2, "Idk: The Spinoff" },
                    { 4, "Okay this is getting out of hand", 2, "Idk: The Spinoff 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
