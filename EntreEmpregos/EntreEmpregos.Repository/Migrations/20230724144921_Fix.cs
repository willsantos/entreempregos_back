using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntreEmpregos.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobJobLevel");

            migrationBuilder.AddColumn<int>(
                name: "JobLevelId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobLevelId",
                table: "Jobs",
                column: "JobLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobLevels_JobLevelId",
                table: "Jobs",
                column: "JobLevelId",
                principalTable: "JobLevels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobLevels_JobLevelId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobLevelId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobLevelId",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "JobJobLevel",
                columns: table => new
                {
                    JobsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LevelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobJobLevel", x => new { x.JobsId, x.LevelsId });
                    table.ForeignKey(
                        name: "FK_JobJobLevel_JobLevels_LevelsId",
                        column: x => x.LevelsId,
                        principalTable: "JobLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobJobLevel_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JobJobLevel_LevelsId",
                table: "JobJobLevel",
                column: "LevelsId");
        }
    }
}
