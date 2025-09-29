using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTS_Training.Migrations
{
    /// <inheritdoc />
    public partial class FixNullData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "PRODUCTS",
                type: "TIMESTAMP(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "PRODUCTS",
                type: "VARCHAR2(20 BYTE)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "ORDERS",
                type: "TIMESTAMP(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "ORDERS",
                type: "VARCHAR2(20 BYTE)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "ORDER_ITEMS",
                type: "TIMESTAMP(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "ORDER_ITEMS",
                type: "VARCHAR2(20 BYTE)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "BUYERS",
                type: "TIMESTAMP(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "BUYERS",
                type: "VARCHAR2(20 BYTE)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "PRODUCTS",
                type: "TIMESTAMP(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "PRODUCTS",
                type: "VARCHAR2(20 BYTE)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "ORDERS",
                type: "TIMESTAMP(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "ORDERS",
                type: "VARCHAR2(20 BYTE)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "ORDER_ITEMS",
                type: "TIMESTAMP(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "ORDER_ITEMS",
                type: "VARCHAR2(20 BYTE)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                schema: "HANVV",
                table: "BUYERS",
                type: "TIMESTAMP(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                schema: "HANVV",
                table: "BUYERS",
                type: "VARCHAR2(20 BYTE)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20 BYTE)",
                oldNullable: true);
        }
    }
}
