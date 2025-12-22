using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMeAI.Migrations
{
    /// <inheritdoc />
    public partial class QuestionLastChangeDateTimeColMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastChange",
                table: "Questions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastChange",
                table: "Questions");
        }
    }
}
