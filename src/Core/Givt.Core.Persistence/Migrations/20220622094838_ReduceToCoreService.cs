using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Givt.Core.Persistence.Migrations
{
    public partial class ReduceToCoreService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationHistory");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "PayOuts");

            migrationBuilder.DropTable(
                name: "PayIns");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    DonationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DonorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fingerprint = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Last4 = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    MediumId = table.Column<Guid>(type: "uuid", nullable: false),
                    PayinId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionReference = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationHistory", x => new { x.Id, x.Modified });
                });

            migrationBuilder.CreateTable(
                name: "PayIns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PayInMethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    DonorOwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExecutedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentProviderExecutionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalPaid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayIns_Donors_DonorOwnerId",
                        column: x => x.DonorOwnerId,
                        principalTable: "Donors",
                        principalColumn: "OwnerId");
                    table.ForeignKey(
                        name: "FK_PayIns_PayInMethod_PayInMethodId",
                        column: x => x.PayInMethodId,
                        principalTable: "PayInMethod",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PayOuts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExecutedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GivtServiceFee = table.Column<decimal>(type: "numeric", nullable: false),
                    GivtServiceFeeTaxes = table.Column<decimal>(type: "numeric", nullable: false),
                    MandateCost = table.Column<decimal>(type: "numeric", nullable: false),
                    MandateCostCount = table.Column<int>(type: "integer", nullable: false),
                    MandateTaxes = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentCost = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentCostTaxes = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentProviderExecutionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PaymentProviderId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RTransactionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    RTransactionT1Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    RTransactionT1Count = table.Column<decimal>(type: "numeric", nullable: false),
                    RTransactionT2Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    RTransactionT2Count = table.Column<decimal>(type: "numeric", nullable: false),
                    RTransactionTaxes = table.Column<decimal>(type: "numeric", nullable: false),
                    RecipientOwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    TotalPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionCost = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionCount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionTaxes = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayOuts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayOuts_Recipients_RecipientOwnerId",
                        column: x => x.RecipientOwnerId,
                        principalTable: "Recipients",
                        principalColumn: "OwnerId");
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    DonorId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediumId = table.Column<Guid>(type: "uuid", nullable: false),
                    PayinId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    DonationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fingerprint = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Last4 = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionReference = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "OwnerId");
                    table.ForeignKey(
                        name: "FK_Donations_Mediums_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Mediums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_PayIns_PayinId",
                        column: x => x.PayinId,
                        principalTable: "PayIns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Donations_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationHistory_TransactionReference",
                table: "DonationHistory",
                column: "TransactionReference");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CampaignId",
                table: "Donations",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_MediumId",
                table: "Donations",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_PayinId",
                table: "Donations",
                column: "PayinId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_RecipientId",
                table: "Donations",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_TransactionReference",
                table: "Donations",
                column: "TransactionReference");

            migrationBuilder.CreateIndex(
                name: "IX_PayIns_DonorOwnerId",
                table: "PayIns",
                column: "DonorOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PayIns_PayInMethodId",
                table: "PayIns",
                column: "PayInMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PayOuts_CampaignId",
                table: "PayOuts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_PayOuts_RecipientOwnerId",
                table: "PayOuts",
                column: "RecipientOwnerId");
        }
    }
}
