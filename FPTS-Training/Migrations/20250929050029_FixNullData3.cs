using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTS_Training.Migrations
{
    /// <inheritdoc />
    public partial class FixNullData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "PRODUCTS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)",
                oldDefaultValueSql: "product_insert_seq.NEXTVAL");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "ORDERS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)",
                oldDefaultValueSql: "product_insert_seq.NEXTVAL");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "ORDER_ITEMS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)",
                oldDefaultValueSql: "product_insert_seq.NEXTVAL");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "BUYERS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)",
                oldDefaultValueSql: "product_insert_seq.NEXTVAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "PRODUCTS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                defaultValueSql: "product_insert_seq.NEXTVAL",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "ORDERS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                defaultValueSql: "product_insert_seq.NEXTVAL",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "ORDER_ITEMS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                defaultValueSql: "product_insert_seq.NEXTVAL",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "HANVV",
                table: "BUYERS",
                type: "VARCHAR2(100 BYTE)",
                nullable: false,
                defaultValueSql: "product_insert_seq.NEXTVAL",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(100 BYTE)");
        }
    }
}
