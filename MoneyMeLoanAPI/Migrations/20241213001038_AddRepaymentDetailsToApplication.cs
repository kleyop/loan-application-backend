using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMeLoanAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRepaymentDetailsToApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EstablishmentFee",
                table: "Applications",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RepaymentAmount",
                table: "Applications",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInterest",
                table: "Applications",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablishmentFee",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "RepaymentAmount",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "TotalInterest",
                table: "Applications");
        }
    }
}
