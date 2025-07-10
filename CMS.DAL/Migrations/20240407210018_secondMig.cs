using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class secondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_ReceiverInfos_ReceiverInfoReceiverID",
                table: "OrderInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_SenderInfos_SenderInfoSenderID",
                table: "OrderInfos");

            migrationBuilder.DropIndex(
                name: "IX_OrderInfos_ReceiverInfoReceiverID",
                table: "OrderInfos");

            migrationBuilder.DropIndex(
                name: "IX_OrderInfos_SenderInfoSenderID",
                table: "OrderInfos");

            migrationBuilder.DropColumn(
                name: "ReceiverInfoReceiverID",
                table: "OrderInfos");

            migrationBuilder.DropColumn(
                name: "SenderInfoSenderID",
                table: "OrderInfos");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_ReceiverId",
                table: "OrderInfos",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_SenderId",
                table: "OrderInfos",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_ReceiverInfos_ReceiverId",
                table: "OrderInfos",
                column: "ReceiverId",
                principalTable: "ReceiverInfos",
                principalColumn: "ReceiverID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_SenderInfos_SenderId",
                table: "OrderInfos",
                column: "SenderId",
                principalTable: "SenderInfos",
                principalColumn: "SenderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_ReceiverInfos_ReceiverId",
                table: "OrderInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_SenderInfos_SenderId",
                table: "OrderInfos");

            migrationBuilder.DropIndex(
                name: "IX_OrderInfos_ReceiverId",
                table: "OrderInfos");

            migrationBuilder.DropIndex(
                name: "IX_OrderInfos_SenderId",
                table: "OrderInfos");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverInfoReceiverID",
                table: "OrderInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderInfoSenderID",
                table: "OrderInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_ReceiverInfoReceiverID",
                table: "OrderInfos",
                column: "ReceiverInfoReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_SenderInfoSenderID",
                table: "OrderInfos",
                column: "SenderInfoSenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_ReceiverInfos_ReceiverInfoReceiverID",
                table: "OrderInfos",
                column: "ReceiverInfoReceiverID",
                principalTable: "ReceiverInfos",
                principalColumn: "ReceiverID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_SenderInfos_SenderInfoSenderID",
                table: "OrderInfos",
                column: "SenderInfoSenderID",
                principalTable: "SenderInfos",
                principalColumn: "SenderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
