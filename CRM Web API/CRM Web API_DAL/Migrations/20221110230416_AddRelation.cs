using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMWebAPIDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "SalesOrderHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "SalesOrderHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeaders_BillingAddressId",
                table: "SalesOrderHeaders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeaders_ShippingAddressId",
                table: "SalesOrderHeaders",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderHeaders_CustomerAddresses_BillingAddressId",
                table: "SalesOrderHeaders",
                column: "BillingAddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderHeaders_CustomerAddresses_ShippingAddressId",
                table: "SalesOrderHeaders",
                column: "ShippingAddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderHeaders_CustomerAddresses_BillingAddressId",
                table: "SalesOrderHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderHeaders_CustomerAddresses_ShippingAddressId",
                table: "SalesOrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderHeaders_BillingAddressId",
                table: "SalesOrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderHeaders_ShippingAddressId",
                table: "SalesOrderHeaders");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "SalesOrderHeaders");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "SalesOrderHeaders");
        }
    }
}
