using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MailOperations.Migrations
{
    public partial class DatabaseChange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Settings",
                newName: "SMTP_Password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Settings",
                newName: "SMTP_Login");

            migrationBuilder.AddColumn<string>(
                name: "FTP_Login",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FTP_Password",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FTP_Path",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pop3_EmailAddress",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pop3_EnableSsl",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Pop3_Login",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pop3_Password",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pop3_SMTP_Host",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pop3_SMTP_Port",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RequestUriString",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SMTP_EmailAddress",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SMTP_EnableSsl",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SMTP_Host",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SMTP_Port",
                table: "Settings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FTP_Login",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FTP_Password",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FTP_Path",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Pop3_EmailAddress",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Pop3_EnableSsl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Pop3_Login",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Pop3_Password",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Pop3_SMTP_Host",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Pop3_SMTP_Port",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "RequestUriString",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SMTP_EmailAddress",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SMTP_EnableSsl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SMTP_Host",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SMTP_Port",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "SMTP_Password",
                table: "Settings",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "SMTP_Login",
                table: "Settings",
                newName: "Login");
        }
    }
}
