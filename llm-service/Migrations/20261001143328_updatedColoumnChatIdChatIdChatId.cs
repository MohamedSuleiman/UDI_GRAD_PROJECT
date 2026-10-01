using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedColoumnChatIdChatIdChatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageEntities_Chats_ChatID",
                table: "ChatMessageEntities");

            migrationBuilder.RenameColumn(
                name: "ChatID",
                table: "ChatMessageEntities",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessageEntities_ChatID",
                table: "ChatMessageEntities",
                newName: "IX_ChatMessageEntities_ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageEntities_Chats_ChatId",
                table: "ChatMessageEntities",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageEntities_Chats_ChatId",
                table: "ChatMessageEntities");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "ChatMessageEntities",
                newName: "ChatID");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessageEntities_ChatId",
                table: "ChatMessageEntities",
                newName: "IX_ChatMessageEntities_ChatID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageEntities_Chats_ChatID",
                table: "ChatMessageEntities",
                column: "ChatID",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
