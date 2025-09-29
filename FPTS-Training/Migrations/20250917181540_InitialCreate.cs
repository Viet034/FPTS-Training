using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTS_Training.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HANVV");

            migrationBuilder.CreateTable(
                name: "BUYERS",
                schema: "HANVV",
                columns: table => new
                {
                    ID = table.Column<string>(type: "VARCHAR2(100 BYTE)", nullable: false, defaultValueSql: "product_insert_seq.NEXTVAL"),
                    PAYMENT_METHOD = table.Column<string>(type: "VARCHAR2(25 BYTE)", nullable: false),
                    CODE = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    CREATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    OFFSETS = table.Column<long>(type: "NUMBER(19,0)", nullable: false),
                    PARTITIONS = table.Column<short>(type: "NUMBER(5,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUYERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEMS",
                schema: "HANVV",
                columns: table => new
                {
                    ID = table.Column<string>(type: "VARCHAR2(100 BYTE)", nullable: false, defaultValueSql: "product_insert_seq.NEXTVAL"),
                    UNITS = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    PRODUCT_ID = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    ORDER_ID = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    CODE = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    CREATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    OFFSETS = table.Column<long>(type: "NUMBER(19,0)", nullable: false),
                    PARTITIONS = table.Column<short>(type: "NUMBER(5,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEMS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                schema: "HANVV",
                columns: table => new
                {
                    ID = table.Column<string>(type: "VARCHAR2(100 BYTE)", nullable: false, defaultValueSql: "product_insert_seq.NEXTVAL"),
                    BUYER_ID = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    ADDRESS = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(1,0)", nullable: false),
                    CODE = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    CREATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    OFFSETS = table.Column<long>(type: "NUMBER(19,0)", nullable: false),
                    PARTITIONS = table.Column<short>(type: "NUMBER(5,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                schema: "HANVV",
                columns: table => new
                {
                    ID = table.Column<string>(type: "VARCHAR2(100 BYTE)", nullable: false, defaultValueSql: "product_insert_seq.NEXTVAL"),
                    STATUS = table.Column<int>(type: "NUMBER(1,0)", nullable: false),
                    CODE = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(6)", nullable: false),
                    CREATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    OFFSETS = table.Column<long>(type: "NUMBER(19,0)", nullable: false),
                    PARTITIONS = table.Column<short>(type: "NUMBER(5,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BUYERS",
                schema: "HANVV");

            migrationBuilder.DropTable(
                name: "ORDER_ITEMS",
                schema: "HANVV");

            migrationBuilder.DropTable(
                name: "ORDERS",
                schema: "HANVV");

            migrationBuilder.DropTable(
                name: "PRODUCTS",
                schema: "HANVV");
        }
    }
}
