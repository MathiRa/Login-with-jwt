using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ALUXION.Repositories.Implementations.Migrations
{
    public partial class fixTextTransfers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tranfers_Genesis_GenesisId",
                table: "Tranfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tranfers_Payments_PaymentId",
                table: "Tranfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tranfers_Users_FromId",
                table: "Tranfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tranfers_Users_ToId",
                table: "Tranfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tranfers",
                table: "Tranfers");

            migrationBuilder.RenameTable(
                name: "Tranfers",
                newName: "Transfers");

            migrationBuilder.RenameIndex(
                name: "IX_Tranfers_ToId",
                table: "Transfers",
                newName: "IX_Transfers_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_Tranfers_PaymentId",
                table: "Transfers",
                newName: "IX_Transfers_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tranfers_GenesisId",
                table: "Transfers",
                newName: "IX_Transfers_GenesisId");

            migrationBuilder.RenameIndex(
                name: "IX_Tranfers_FromId",
                table: "Transfers",
                newName: "IX_Transfers_FromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Genesis_GenesisId",
                table: "Transfers",
                column: "GenesisId",
                principalTable: "Genesis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Payments_PaymentId",
                table: "Transfers",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Users_FromId",
                table: "Transfers",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Users_ToId",
                table: "Transfers",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Genesis_GenesisId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Payments_PaymentId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Users_FromId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Users_ToId",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.RenameTable(
                name: "Transfers",
                newName: "Tranfers");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_ToId",
                table: "Tranfers",
                newName: "IX_Tranfers_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_PaymentId",
                table: "Tranfers",
                newName: "IX_Tranfers_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_GenesisId",
                table: "Tranfers",
                newName: "IX_Tranfers_GenesisId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_FromId",
                table: "Tranfers",
                newName: "IX_Tranfers_FromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tranfers",
                table: "Tranfers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranfers_Genesis_GenesisId",
                table: "Tranfers",
                column: "GenesisId",
                principalTable: "Genesis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tranfers_Payments_PaymentId",
                table: "Tranfers",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranfers_Users_FromId",
                table: "Tranfers",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranfers_Users_ToId",
                table: "Tranfers",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
