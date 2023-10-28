using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EnableIdentityInsertForSurveyors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Surveyors ON");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Surveyors OFF");
        }
    }
}
