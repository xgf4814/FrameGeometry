using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrameGeometry1.Data.Migrations
{
    public partial class argh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geometry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HTA = table.Column<double>(nullable: false),
                    HTL = table.Column<double>(nullable: false),
                    STA = table.Column<double>(nullable: false),
                    STL = table.Column<double>(nullable: false),
                    bbdrop = table.Column<double>(nullable: false),
                    chainstay = table.Column<double>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    enabled = table.Column<bool>(nullable: false),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    reach = table.Column<double>(nullable: false),
                    size = table.Column<string>(nullable: true),
                    stack = table.Column<double>(nullable: false),
                    standover = table.Column<double>(nullable: false),
                    wheelbase = table.Column<double>(nullable: false),
                    wheeldiameter = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geometry", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Geometry");
        }
    }
}
