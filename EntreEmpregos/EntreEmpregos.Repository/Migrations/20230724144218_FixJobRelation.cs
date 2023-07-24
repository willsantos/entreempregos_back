using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntreEmpregos.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixJobRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobJobRegion");

            migrationBuilder.AddColumn<int>(
                name: "JobRegionId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobRegionId",
                table: "Jobs",
                column: "JobRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobRegions_JobRegionId",
                table: "Jobs",
                column: "JobRegionId",
                principalTable: "JobRegions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobRegions_JobRegionId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobRegionId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobRegionId",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "JobJobRegion",
                columns: table => new
                {
                    JobsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RegionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobJobRegion", x => new { x.JobsId, x.RegionsId });
                    table.ForeignKey(
                        name: "FK_JobJobRegion_JobRegions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "JobRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobJobRegion_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JobJobRegion_RegionsId",
                table: "JobJobRegion",
                column: "RegionsId");
        }
    }
}
