using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Givt.Core.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppVersion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    BuildNumber = table.Column<int>(type: "integer", nullable: false),
                    OperatingSystem = table.Column<int>(type: "integer", nullable: false),
                    IsCritical = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Percentage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EmailNormalised = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    OS = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EmailNormalised);
                });

            migrationBuilder.CreateTable(
                name: "Authorisations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserEmailNormalised = table.Column<string>(type: "character varying(200)", nullable: true),
                    RecipientOwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    DonorOwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorisations", x => new { x.UserId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_Authorisations_Users_UserEmailNormalised",
                        column: x => x.UserEmailNormalised,
                        principalTable: "Users",
                        principalColumn: "EmailNormalised");
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Namespace = table.Column<string>(type: "character varying(33)", maxLength: 33, nullable: true),
                    Amounts = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DefaultFeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PayOutMethodId = table.Column<Guid>(type: "uuid", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "CampaignTexts",
                columns: table => new
                {
                    LanguageId = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(175)", maxLength: 175, nullable: true),
                    Goal = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    ThankYou = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    GivtOfficeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentMethods = table.Column<ulong>(type: "numeric(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LegalEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Preposition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(175)", maxLength: 175, nullable: true),
                    EmailAddress = table.Column<string>(type: "character varying(175)", maxLength: 175, nullable: true),
                    Url = table.Column<string>(type: "character varying(175)", maxLength: 175, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConcurrencyToken = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now() ON UPDATE now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "GivtOffice",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WantKnowMore = table.Column<string>(type: "character varying(175)", maxLength: 175, nullable: true),
                    GivtPrivacyPolicy = table.Column<string>(type: "character varying(175)", maxLength: 175, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GivtOffice", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_GivtOffice_LegalEntities_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PrimaryPayInMethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    TimeZoneId = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "PayInMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PSP_Owner = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PSP_Identification = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    Last4 = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Fingerprint = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "FeeAgreements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    MinVolumeCount = table.Column<int>(type: "integer", nullable: true),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    MinVolumeAmount = table.Column<int>(type: "integer", nullable: true),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Mediums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    MediumId = table.Column<string>(type: "character varying(33)", maxLength: 33, nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Lat = table.Column<float>(type: "real", nullable: true),
                    Lon = table.Column<float>(type: "real", nullable: true),
                    Radius = table.Column<int>(type: "integer", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "PayOutMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    PSP_Owner = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PSP_Identification = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayOutMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(175)", maxLength: 175, nullable: true),
                    LogoImageLink = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PaymentMethods = table.Column<ulong>(type: "numeric(20,0)", nullable: true),
                    PrimaryPayOutMethodId = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultCampaignId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Recipients_Campaigns_DefaultCampaignId",
                        column: x => x.DefaultCampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
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
                });

            migrationBuilder.CreateTable(
                name: "Timeslots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediumId = table.Column<Guid>(type: "uuid", nullable: false)
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
                });

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
                name: "IX_PayOutMethod_RecipientId",
                table: "PayOutMethod",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_DefaultCampaignId",
                table: "Recipients",
                column: "DefaultCampaignId",
                unique: true);

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
                name: "FK_Countries_GivtOffice_GivtOfficeId",
                table: "Countries",
                column: "GivtOfficeId",
                principalTable: "GivtOffice",
                principalColumn: "OwnerId");

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
                name: "FK_Countries_GivtOffice_GivtOfficeId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "AppVersion");

            migrationBuilder.DropTable(
                name: "Authorisations");

            migrationBuilder.DropTable(
                name: "CampaignTexts");

            migrationBuilder.DropTable(
                name: "FeeAgreements");

            migrationBuilder.DropTable(
                name: "Timeslots");

            migrationBuilder.DropTable(
                name: "Users");

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
                name: "GivtOffice");

            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
