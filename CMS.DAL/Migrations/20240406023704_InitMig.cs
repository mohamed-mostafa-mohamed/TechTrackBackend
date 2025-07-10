using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiverInfos",
                columns: table => new
                {
                    ReceiverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    ReceiverEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverStreet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverInfos", x => x.ReceiverID);
                });

            migrationBuilder.CreateTable(
                name: "SenderInfos",
                columns: table => new
                {
                    SenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderStreet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderInfos", x => x.SenderID);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemWeightKG = table.Column<float>(type: "real", nullable: false),
                    NumberOfItem = table.Column<int>(type: "int", nullable: false),
                    OrderNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WayBillStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAmount = table.Column<float>(type: "real", nullable: false),
                    BillingFeeInKG = table.Column<float>(type: "real", nullable: false),
                    BillingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderInfoSenderID = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverInfoReceiverID = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderInfos_ReceiverInfos_ReceiverInfoReceiverID",
                        column: x => x.ReceiverInfoReceiverID,
                        principalTable: "ReceiverInfos",
                        principalColumn: "ReceiverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderInfos_SenderInfos_SenderInfoSenderID",
                        column: x => x.SenderInfoSenderID,
                        principalTable: "SenderInfos",
                        principalColumn: "SenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiverInfoSenderInfo",
                columns: table => new
                {
                    ReceiversReceiverID = table.Column<int>(type: "int", nullable: false),
                    ReceiversSenderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverInfoSenderInfo", x => new { x.ReceiversReceiverID, x.ReceiversSenderID });
                    table.ForeignKey(
                        name: "FK_ReceiverInfoSenderInfo_ReceiverInfos_ReceiversReceiverID",
                        column: x => x.ReceiversReceiverID,
                        principalTable: "ReceiverInfos",
                        principalColumn: "ReceiverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiverInfoSenderInfo_SenderInfos_ReceiversSenderID",
                        column: x => x.ReceiversSenderID,
                        principalTable: "SenderInfos",
                        principalColumn: "SenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbnormalOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubReasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbnormalOrders_OrderInfos_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalOrders_OrderId",
                table: "AbnormalOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_ReceiverInfoReceiverID",
                table: "OrderInfos",
                column: "ReceiverInfoReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_SenderInfoSenderID",
                table: "OrderInfos",
                column: "SenderInfoSenderID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverInfoSenderInfo_ReceiversSenderID",
                table: "ReceiverInfoSenderInfo",
                column: "ReceiversSenderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbnormalOrders");

            migrationBuilder.DropTable(
                name: "ReceiverInfoSenderInfo");

            migrationBuilder.DropTable(
                name: "OrderInfos");

            migrationBuilder.DropTable(
                name: "ReceiverInfos");

            migrationBuilder.DropTable(
                name: "SenderInfos");
        }
    }
}
