using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Attendence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultsSheets_ClassLevels_ClassId",
                table: "ResultsSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsSheets_Students_StudentId",
                table: "ResultsSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsSheets_Subjects_SubjectId",
                table: "ResultsSheets");

            migrationBuilder.DropIndex(
                name: "IX_Attenants_StudentId",
                table: "Attenants");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Attenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectId",
                table: "Subjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Attenants_StudentId",
                table: "Attenants",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attenants_SubjectId",
                table: "Attenants",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attenants_Subjects_SubjectId",
                table: "Attenants",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsSheets_ClassLevels_ClassId",
                table: "ResultsSheets",
                column: "ClassId",
                principalTable: "ClassLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsSheets_Students_StudentId",
                table: "ResultsSheets",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsSheets_Subjects_SubjectId",
                table: "ResultsSheets",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Subjects_SubjectId",
                table: "Subjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attenants_Subjects_SubjectId",
                table: "Attenants");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsSheets_ClassLevels_ClassId",
                table: "ResultsSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsSheets_Students_StudentId",
                table: "ResultsSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsSheets_Subjects_SubjectId",
                table: "ResultsSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Subjects_SubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Attenants_StudentId",
                table: "Attenants");

            migrationBuilder.DropIndex(
                name: "IX_Attenants_SubjectId",
                table: "Attenants");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Attenants");

            migrationBuilder.CreateIndex(
                name: "IX_Attenants_StudentId",
                table: "Attenants",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsSheets_ClassLevels_ClassId",
                table: "ResultsSheets",
                column: "ClassId",
                principalTable: "ClassLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsSheets_Students_StudentId",
                table: "ResultsSheets",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsSheets_Subjects_SubjectId",
                table: "ResultsSheets",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
