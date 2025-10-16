using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addDomainAndUniqueToNameInTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Tenants",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Name",
                table: "Tenants",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tenants_Name",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Tenants");
        }
    }
}
