using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class changesinfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_IdentityUserId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IndentityUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IndentityUserId",
                table: "Bids");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Bids",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_IdentityUserId",
                table: "Bids",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_IdentityUserId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IndentityUserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Bids",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IndentityUserId",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_IdentityUserId",
                table: "Bids",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
