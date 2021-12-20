using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachingManagement.Migrations
{
    public partial class newchangess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_Course_courseId",
                table: "student");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "student",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_student_courseId",
                table: "student",
                newName: "IX_student_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_student_Course_CourseId",
                table: "student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_Course_CourseId",
                table: "student");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "student",
                newName: "courseId");

            migrationBuilder.RenameIndex(
                name: "IX_student_CourseId",
                table: "student",
                newName: "IX_student_courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_student_Course_courseId",
                table: "student",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
