using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMeAI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelPropertiesSyntax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleID",
                table: "Title",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Question",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Title",
                newName: "TitleID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Question",
                newName: "QuestionId");
        }
    }
}
