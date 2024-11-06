using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Savings.Migrations.Migrations
{
    public partial class SavingsDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    PnDEnabled = table.Column<bool>(nullable: false),
                    PnCEnabled = table.Column<bool>(nullable: false),
                    LienEnabled = table.Column<bool>(nullable: false),
                    Tier = table.Column<int>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    LedgerBalance = table.Column<long>(nullable: false),
                    AvailableBalance = table.Column<long>(nullable: false),
                    OpeningBalance = table.Column<long>(nullable: false),
                    ClosingBalance = table.Column<long>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Country = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Savingss",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GoalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetDate = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savingss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Savingss_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Savingss_AccountId",
                table: "Savingss",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Savingss");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
