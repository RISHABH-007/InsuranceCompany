using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    FeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimateStartLimit = table.Column<int>(type: "int", nullable: false),
                    EstimateEndLimit = table.Column<int>(type: "int", nullable: false),
                    fees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.FeeId);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyNo = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    InsuredFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuredLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfInsurance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyNo);
                });

            migrationBuilder.CreateTable(
                name: "Surveyors",
                columns: table => new
                {
                    SurveyorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimateLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyors", x => x.SurveyorId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDetails",
                columns: table => new
                {
                    ClaimId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PolicyNo = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    EstimatedLoss = table.Column<int>(type: "int", nullable: false),
                    DateOfAccident = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimStatus = table.Column<bool>(type: "bit", nullable: false),
                    SurveyorId = table.Column<int>(type: "int", nullable: false),
                    AmtApprovedBySurveyor = table.Column<int>(type: "int", nullable: false),
                    InsuranceCompanyApproval = table.Column<bool>(type: "bit", nullable: false),
                    WithdrawClaim = table.Column<bool>(type: "bit", nullable: false),
                    SurveyorFees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDetails", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_ClaimDetails_Policies_PolicyNo",
                        column: x => x.PolicyNo,
                        principalTable: "Policies",
                        principalColumn: "PolicyNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimDetails_Surveyors_SurveyorId",
                        column: x => x.SurveyorId,
                        principalTable: "Surveyors",
                        principalColumn: "SurveyorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDetails_PolicyNo",
                table: "ClaimDetails",
                column: "PolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDetails_SurveyorId",
                table: "ClaimDetails",
                column: "SurveyorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimDetails");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Surveyors");
        }
    }
}
