using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCEntityFrameWork.Migrations
{
    public partial class updatebookmodeladdfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "BookInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "BookInfo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "BookInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumOfPages",
                table: "BookInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "BookInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublishYear",
                table: "BookInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "Weight",
                table: "BookInfo",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "BookInfo");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "BookInfo");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "BookInfo");

            migrationBuilder.DropColumn(
                name: "NumOfPages",
                table: "BookInfo");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "BookInfo");

            migrationBuilder.DropColumn(
                name: "PublishYear",
                table: "BookInfo");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "BookInfo");
        }
    }
}
