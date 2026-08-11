using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialNetwork.Migrations
{
    /// <inheritdoc />
    public partial class SeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "Id", "StartedAt", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 24, 14, 30, 0, 0, DateTimeKind.Unspecified), "Project Discussion" },
                    { 2, new DateTime(2025, 2, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), "Weekend Plans" },
                    { 3, new DateTime(2025, 2, 23, 10, 15, 0, 0, DateTimeKind.Unspecified), "Team Meeting" },
                    { 4, new DateTime(2025, 1, 31, 16, 23, 0, 0, DateTimeKind.Unspecified), "Movie Night" },
                    { 5, new DateTime(2024, 8, 10, 20, 11, 0, 0, DateTimeKind.Unspecified), "BackUp Group" },
                    { 6, new DateTime(2024, 8, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Study Group" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "john@example.com", "Pass123", "john_doe" },
                    { 2, "jane@example.com", "Secure456", "jane_doe" },
                    { 3, "alex_sm@mail.com", "TestPass789", "alex_smith" },
                    { 4, "sara_m@mail.com", "MillerPass99", "sara_miller" },
                    { 5, "michael_b@mail.com", "BrownSecret88", "michael_brown" },
                    { 6, "emily_w@mail.com", "EmilyW12345", "emily_white" },
                    { 7, "david_j@mail.com", "JacksonD777", "david_jackson" },
                    { 8, "olivia_t@mail.com", "TaylorOlivia12", "olivia_taylor" },
                    { 9, "william_c@mail.com", "ClarkWill99", "william_clark" }
                });

            migrationBuilder.InsertData(
                table: "Friendships",
                columns: new[] { "UserOneId", "UserTwoId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 7 },
                    { 1, 9 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 8 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 8 },
                    { 4, 1 },
                    { 4, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 6, 8 },
                    { 7, 9 },
                    { 8, 9 },
                    { 9, 2 }
                });

            migrationBuilder.InsertData(
                table: "UsersConversations",
                columns: new[] { "ConversationId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 3, 5 },
                    { 5, 5 },
                    { 2, 6 },
                    { 3, 6 },
                    { 6, 6 },
                    { 1, 7 },
                    { 3, 7 },
                    { 2, 8 },
                    { 3, 8 },
                    { 6, 8 },
                    { 1, 9 },
                    { 3, 9 },
                    { 5, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "Friendships",
                keyColumns: new[] { "UserOneId", "UserTwoId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "UsersConversations",
                keyColumns: new[] { "ConversationId", "UserId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "Conversations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Conversations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Conversations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Conversations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Conversations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Conversations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
