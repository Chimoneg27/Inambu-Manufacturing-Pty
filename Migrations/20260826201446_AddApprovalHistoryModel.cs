using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InambuManufacturingPty.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalHistoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalHistoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapitalExId = table.Column<int>(type: "int", nullable: false),
                    CapitalExRequestId = table.Column<int>(type: "int", nullable: true),
                    ActionByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedOrRejectedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalHistoryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalHistoryModel_AspNetUsers_ActionByUserId",
                        column: x => x.ActionByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalHistoryModel_CapitalExRequestModels_CapitalExRequestId",
                        column: x => x.CapitalExRequestId,
                        principalTable: "CapitalExRequestModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistoryModel_ActionByUserId",
                table: "ApprovalHistoryModel",
                column: "ActionByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistoryModel_CapitalExRequestId",
                table: "ApprovalHistoryModel",
                column: "CapitalExRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalHistoryModel");
        }
    }
}
