using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommanLayer.Migrations
{
    public partial class QuantityMeasurementComparison : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comparisons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeasurementType = table.Column<string>(nullable: false),
                    FirstValueUnit = table.Column<string>(nullable: false),
                    FirstValue = table.Column<double>(nullable: false),
                    SecondValueUnit = table.Column<string>(nullable: false),
                    SecondValue = table.Column<double>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparisons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comparisons");
        }
    }
}
