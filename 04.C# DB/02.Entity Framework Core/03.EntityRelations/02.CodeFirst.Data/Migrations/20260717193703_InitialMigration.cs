using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The id of the author - primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the author - required, maximum of 50 and supports unicode")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                },
                comment: "Represents the author of a post");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false, comment: "The Id of the Post, also it's Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The title of the post - it is required, has a max length of 200 and supports unicode"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "The content of the post - it is required, has a max length of 2 000 and supports unicode"),
                    AuthorId = table.Column<int>(type: "int", nullable: false, comment: "The Id of the author - foreign key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a blog post");

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The id of the reply - primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "The content of the reply - required, has a maximum of 1 000 and supports unicode"),
                    PostId = table.Column<int>(type: "int", nullable: false, comment: "The id of the post - foreign key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A reply to a post");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Title",
                table: "Posts",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PostId",
                table: "Replies",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
