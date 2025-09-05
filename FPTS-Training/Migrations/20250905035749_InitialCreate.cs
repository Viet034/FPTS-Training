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
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    PAYMENT_METHOD = table.Column<string>(type: "VARCHAR2(25 BYTE)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UpdateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Offsets = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Partitions = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUYERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEMS",
                schema: "HANVV",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UNITS = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    PRODUCT_ID = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    ORDER_ID = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UpdateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Offsets = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Partitions = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                schema: "HANVV",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    BUYER_ID = table.Column<string>(type: "VARCHAR2(5 BYTE)", nullable: false),
                    ADDRESS = table.Column<string>(type: "VARCHAR2(20 BYTE)", nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(1,0)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UpdateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Offsets = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Partitions = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                schema: "HANVV",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(1,0)", nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UpdateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Offsets = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Partitions = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Id);
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
