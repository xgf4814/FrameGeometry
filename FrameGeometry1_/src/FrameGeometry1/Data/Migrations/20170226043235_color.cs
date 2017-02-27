using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrameGeometry1.Data.Migrations
{
    public partial class color : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Geometry",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "Geometry",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "Geometry");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "Geometry");
        }
    }
}
