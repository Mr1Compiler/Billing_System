using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRenewableColumnInCustomerSub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRenewable",
                table: "CustomerSubscriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRenewable",
                table: "CustomerSubscriptions");
        }
    }
}
