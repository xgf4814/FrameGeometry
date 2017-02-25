using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrameGeometry1.Data.Migrations
{
    public partial class MakeModelSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "make",
                table: "Geometry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "Geometry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Geometry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "make",
                table: "Geometry");

            migrationBuilder.DropColumn(
                name: "model",
                table: "Geometry");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Geometry");
        }
    }
}
