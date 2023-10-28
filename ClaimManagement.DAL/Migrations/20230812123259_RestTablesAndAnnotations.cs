using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RestTablesAndAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentOfClaims",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOfClaims", x => x.reportId);
                });

            migrationBuilder.CreateTable(
                name: "PendingStatusReport",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingStatusReport", x => x.reportId);
                });

            migrationBuilder.CreateTable(
                name: "SurveyReport",
                columns: table => new
                {
                    ClaimId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PolicyNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabourCharges = table.Column<int>(type: "int", nullable: false),
                    PartsCost = table.Column<int>(type: "int", nullable: false),
                    PolicyClass = table.Column<int>(type: "int", nullable: false),
                    DepreciationCost = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyReport", x => x.ClaimId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentOfClaims");

            migrationBuilder.DropTable(
                name: "PendingStatusReport");

            migrationBuilder.DropTable(
                name: "SurveyReport");
        }
    }
}
