using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiyCustomerLoansAndSuppliersLoansTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerLoans_Goods_GoodId",
                table: "CustomerLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierLoans_Goods_GoodId",
                table: "SupplierLoans");

            migrationBuilder.DropIndex(
                name: "IX_SupplierLoans_GoodId",
                table: "SupplierLoans");

            migrationBuilder.DropIndex(
                name: "IX_CustomerLoans_GoodId",
                table: "CustomerLoans");

            migrationBuilder.DropColumn(
                name: "GoodId",
                table: "SupplierLoans");

            migrationBuilder.DropColumn(
                name: "GoodId",
                table: "CustomerLoans");

            migrationBuilder.AlterColumn<int>(
                name: "UnitPurchasePrice",
                table: "Purchases",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "UnPaidAmount",
                table: "Purchases",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "Purchases",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "PaidAmount",
                table: "Purchases",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodId",
                table: "SupplierLoans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "UnitPurchasePrice",
                table: "Purchases",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "UnPaidAmount",
                table: "Purchases",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Purchases",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "PaidAmount",
                table: "Purchases",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "GoodId",
                table: "CustomerLoans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierLoans_GoodId",
                table: "SupplierLoans",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLoans_GoodId",
                table: "CustomerLoans",
                column: "GoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerLoans_Goods_GoodId",
                table: "CustomerLoans",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierLoans_Goods_GoodId",
                table: "SupplierLoans",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
