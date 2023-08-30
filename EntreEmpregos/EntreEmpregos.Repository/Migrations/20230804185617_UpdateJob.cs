using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntreEmpregos.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobLevels_JobLevelId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobRegions_JobRegionId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobLevelId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobRegionId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobLevelId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobRegionId",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_LevelId",
                table: "Jobs",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_RegionId",
                table: "Jobs",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobLevels_LevelId",
                table: "Jobs",
                column: "LevelId",
                principalTable: "JobLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobRegions_RegionId",
                table: "Jobs",
                column: "RegionId",
                principalTable: "JobRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobLevels_LevelId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobRegions_RegionId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_LevelId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_RegionId",
                table: "Jobs");

            migrationBuilder.AddColumn<Guid>(
                name: "JobLevelId",
                table: "Jobs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "JobRegionId",
                table: "Jobs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobLevelId",
                table: "Jobs",
                column: "JobLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobRegionId",
                table: "Jobs",
                column: "JobRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobLevels_JobLevelId",
                table: "Jobs",
                column: "JobLevelId",
                principalTable: "JobLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobRegions_JobRegionId",
                table: "Jobs",
                column: "JobRegionId",
                principalTable: "JobRegions",
                principalColumn: "Id");
        }
    }
}
