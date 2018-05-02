using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HouseholdExpensesTrackerServer.Infrastructure.Migrations
{
    public partial class RowVersionToVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SavingTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "CredentialTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Credentials");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "SavingTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Savings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Permissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Households",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "ExpenseTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "CredentialTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Credentials",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "SavingTypes");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "CredentialTypes");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Credentials");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Users",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SavingTypes",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Savings",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Roles",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Permissions",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Households",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ExpenseTypes",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Expenses",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "CredentialTypes",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Credentials",
                rowVersion: true,
                nullable: true);
        }
    }
}
