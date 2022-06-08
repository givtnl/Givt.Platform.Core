using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Givt.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppVersion",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    BuildNumber = table.Column<int>(type: "int", nullable: false),
                    OperatingSystem = table.Column<int>(type: "int", nullable: false),
                    IsCritical = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EmailNormalised = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EmailNormalised);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authorisations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResourceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserEmailNormalised = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecipientOwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: true),
                    DonorOwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorisations", x => new { x.UserId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_Authorisations_Users_UserEmailNormalised",
                        column: x => x.UserEmailNormalised,
                        principalTable: "Users",
                        principalColumn: "EmailNormalised");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    OwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Namespace = table.Column<string>(type: "varchar(33)", maxLength: 33, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amounts = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DefaultFeeId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    PayOutMethodId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Fees_DefaultFeeId",
                        column: x => x.DefaultFeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampaignTexts",
                columns: table => new
                {
                    LanguageId = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CampaignId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Title = table.Column<string>(type: "varchar(175)", maxLength: 175, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Goal = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThankYou = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTexts", x => new { x.CampaignId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CampaignTexts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GivtOfficeId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    PaymentMethods = table.Column<ulong>(type: "BIGINT UNSIGNED", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LegalEntities",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preposition = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(175)", maxLength: 175, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "varchar(175)", maxLength: 175, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(175)", maxLength: 175, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyToken = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
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
                    ConcurrencyToken = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    OwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    PrimaryPayInMethodId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Language = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeZoneId = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Donors_LegalEntities_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayInMethod",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    OwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    PSP_Owner = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PSP_Identification = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Last4 = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fingerprint = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayInMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayInMethod_Donors_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Donors",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayIns",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExecutedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentProviderExecutionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayInMethodId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    TotalPaid = table.Column<int>(type: "int", nullable: false),
                    DonorOwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FeeAgreements",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    CampaignId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    RecipientId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    FeeId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    MinVolumeCount = table.Column<int>(type: "int", nullable: true),
                    Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MinVolumeAmount = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeAgreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeAgreements_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeeAgreements_Fees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mediums",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    MediumId = table.Column<string>(type: "varchar(33)", maxLength: 33, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CampaignId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lat = table.Column<float>(type: "float", nullable: true),
                    Lon = table.Column<float>(type: "float", nullable: true),
                    Radius = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mediums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mediums_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayOutMethod",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    RecipientId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    PSP_Owner = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PSP_Identification = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayOutMethod", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    OwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(175)", maxLength: 175, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoImageLink = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrimaryPayOutMethodId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    DefaultCampaignId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Recipients_Campaigns_DefaultCampaignId",
                        column: x => x.DefaultCampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipients_LegalEntities_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipients_PayOutMethod_PrimaryPayOutMethodId",
                        column: x => x.PrimaryPayOutMethodId,
                        principalTable: "PayOutMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayOuts",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExecutedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentProviderExecutionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransactionCount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TransactionCost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TransactionTaxes = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MandateCostCount = table.Column<int>(type: "int", nullable: false),
                    MandateCost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MandateTaxes = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RTransactionT1Count = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RTransactionT1Cost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RTransactionT2Count = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RTransactionT2Cost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RTransactionAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RTransactionTaxes = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GivtServiceFee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GivtServiceFeeTaxes = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentCost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentCostTaxes = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalPaid = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentProviderId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CampaignId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    RecipientOwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Timeslots",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false, defaultValueSql: "(UUID())"),
                    OwnerId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CampaignId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    MediumId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timeslots_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timeslots_Mediums_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Mediums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timeslots_Recipients_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Recipients",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Authorisations_DonorOwnerId",
                table: "Authorisations",
                column: "DonorOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorisations_RecipientOwnerId",
                table: "Authorisations",
                column: "RecipientOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorisations_UserEmailNormalised",
                table: "Authorisations",
                column: "UserEmailNormalised");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_DefaultFeeId",
                table: "Campaigns",
                column: "DefaultFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_OwnerId",
                table: "Campaigns",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_PayOutMethodId",
                table: "Campaigns",
                column: "PayOutMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GivtOfficeId",
                table: "Countries",
                column: "GivtOfficeId");

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
                name: "IX_Donors_PrimaryPayInMethodId",
                table: "Donors",
                column: "PrimaryPayInMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeAgreements_CampaignId",
                table: "FeeAgreements",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeAgreements_FeeId",
                table: "FeeAgreements",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeAgreements_RecipientId",
                table: "FeeAgreements",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntities_CountryId",
                table: "LegalEntities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Mediums_CampaignId",
                table: "Mediums",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Mediums_OwnerId",
                table: "Mediums",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PayInMethod_OwnerId",
                table: "PayInMethod",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PayIns_DonorOwnerId",
                table: "PayIns",
                column: "DonorOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PayIns_PayInMethodId",
                table: "PayIns",
                column: "PayInMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PayOutMethod_RecipientId",
                table: "PayOutMethod",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_PayOuts_CampaignId",
                table: "PayOuts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_PayOuts_RecipientOwnerId",
                table: "PayOuts",
                column: "RecipientOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_DefaultCampaignId",
                table: "Recipients",
                column: "DefaultCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_PrimaryPayOutMethodId",
                table: "Recipients",
                column: "PrimaryPayOutMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_CampaignId",
                table: "Timeslots",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_MediumId",
                table: "Timeslots",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_OwnerId",
                table: "Timeslots",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorisations_Donors_DonorOwnerId",
                table: "Authorisations",
                column: "DonorOwnerId",
                principalTable: "Donors",
                principalColumn: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorisations_Recipients_RecipientOwnerId",
                table: "Authorisations",
                column: "RecipientOwnerId",
                principalTable: "Recipients",
                principalColumn: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_PayOutMethod_PayOutMethodId",
                table: "Campaigns",
                column: "PayOutMethodId",
                principalTable: "PayOutMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Recipients_OwnerId",
                table: "Campaigns",
                column: "OwnerId",
                principalTable: "Recipients",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_LegalEntities_GivtOfficeId",
                table: "Countries",
                column: "GivtOfficeId",
                principalTable: "LegalEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Mediums_MediumId",
                table: "Donations",
                column: "MediumId",
                principalTable: "Mediums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_PayIns_PayinId",
                table: "Donations",
                column: "PayinId",
                principalTable: "PayIns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Recipients_RecipientId",
                table: "Donations",
                column: "RecipientId",
                principalTable: "Recipients",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_PayInMethod_PrimaryPayInMethodId",
                table: "Donors",
                column: "PrimaryPayInMethodId",
                principalTable: "PayInMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeeAgreements_Recipients_RecipientId",
                table: "FeeAgreements",
                column: "RecipientId",
                principalTable: "Recipients",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mediums_Recipients_OwnerId",
                table: "Mediums",
                column: "OwnerId",
                principalTable: "Recipients",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayOutMethod_Recipients_RecipientId",
                table: "PayOutMethod",
                column: "RecipientId",
                principalTable: "Recipients",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayInMethod_Donors_OwnerId",
                table: "PayInMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Recipients_OwnerId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_PayOutMethod_Recipients_RecipientId",
                table: "PayOutMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_LegalEntities_GivtOfficeId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "AppVersion");

            migrationBuilder.DropTable(
                name: "Authorisations");

            migrationBuilder.DropTable(
                name: "CampaignTexts");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "FeeAgreements");

            migrationBuilder.DropTable(
                name: "PayOuts");

            migrationBuilder.DropTable(
                name: "Timeslots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PayIns");

            migrationBuilder.DropTable(
                name: "Mediums");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "PayInMethod");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "PayOutMethod");

            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
