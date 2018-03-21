using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PrivateSquares.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    EmailVerification = table.Column<Guid>(nullable: false),
                    FirtsName = table.Column<string>(maxLength: 50, nullable: true),
                    IsActived = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 10, nullable: true),
                    ModifyOn = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: true),
                    Photo = table.Column<string>(maxLength: 200, nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
