using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InambuManufacturingPty.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalHistoryModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalHistoryModel_AspNetUsers_ActionByUserId",
                table: "ApprovalHistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalHistoryModel_CapitalExRequestModels_CapitalExRequestId",
                table: "ApprovalHistoryModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalHistoryModel",
                table: "ApprovalHistoryModel");

            migrationBuilder.RenameTable(
                name: "ApprovalHistoryModel",
                newName: "ApprovalHistoryModels");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalHistoryModel_CapitalExRequestId",
                table: "ApprovalHistoryModels",
                newName: "IX_ApprovalHistoryModels_CapitalExRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalHistoryModel_ActionByUserId",
                table: "ApprovalHistoryModels",
                newName: "IX_ApprovalHistoryModels_ActionByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalHistoryModels",
                table: "ApprovalHistoryModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalHistoryModels_AspNetUsers_ActionByUserId",
                table: "ApprovalHistoryModels",
                column: "ActionByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalHistoryModels_CapitalExRequestModels_CapitalExRequestId",
                table: "ApprovalHistoryModels",
                column: "CapitalExRequestId",
                principalTable: "CapitalExRequestModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalHistoryModels_AspNetUsers_ActionByUserId",
                table: "ApprovalHistoryModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalHistoryModels_CapitalExRequestModels_CapitalExRequestId",
                table: "ApprovalHistoryModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalHistoryModels",
                table: "ApprovalHistoryModels");

            migrationBuilder.RenameTable(
                name: "ApprovalHistoryModels",
                newName: "ApprovalHistoryModel");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalHistoryModels_CapitalExRequestId",
                table: "ApprovalHistoryModel",
                newName: "IX_ApprovalHistoryModel_CapitalExRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalHistoryModels_ActionByUserId",
                table: "ApprovalHistoryModel",
                newName: "IX_ApprovalHistoryModel_ActionByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalHistoryModel",
                table: "ApprovalHistoryModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalHistoryModel_AspNetUsers_ActionByUserId",
                table: "ApprovalHistoryModel",
                column: "ActionByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalHistoryModel_CapitalExRequestModels_CapitalExRequestId",
                table: "ApprovalHistoryModel",
                column: "CapitalExRequestId",
                principalTable: "CapitalExRequestModels",
                principalColumn: "Id");
        }
    }
}
