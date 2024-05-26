using Microsoft.EntityFrameworkCore.Migrations;

namespace ScooterService.Migrations
{
    public partial class IssueSeed : Migration
     {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Name", "HoursOfWork", "ReparationId" },
                values: new object[] { 1L, "Schimbare roata", 2, 1L});


        }
    }
}
