using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMeAI.Migrations
{
    /// <inheritdoc />
    public partial class UsersColsEditMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UsersId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UsersId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Questions",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Questions",
                newName: "UserID");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UsersId",
                table: "Questions",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UsersId",
                table: "Questions",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
