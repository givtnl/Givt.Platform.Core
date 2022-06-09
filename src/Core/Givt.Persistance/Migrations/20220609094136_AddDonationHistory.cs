using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Givt.Persistance.Migrations
{
    public partial class AddDonationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MediumId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    DonorId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    RecipientId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CampaignId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DonationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TransactionReference = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayinId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Last4 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fingerprint = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reason = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationHistory", x => new { x.Id, x.Modified });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistory_TransactionReference",
                table: "DonationHistory",
                column: "TransactionReference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationHistory");
        }
    }
}
