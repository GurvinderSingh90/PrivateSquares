using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PrivateSquares.Data.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Verifies_VerifyID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VerifyID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerifyID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VerifyID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_VerifyID",
                table: "Users",
                column: "VerifyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Verifies_VerifyID",
                table: "Users",
                column: "VerifyID",
                principalTable: "Verifies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
