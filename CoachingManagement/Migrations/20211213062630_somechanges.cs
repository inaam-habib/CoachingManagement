using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachingManagement.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Course__Teacher_teacherId",
                table: "_Course");

            migrationBuilder.DropForeignKey(
                name: "FK__student__Course_courseId",
                table: "_student");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Teacher",
                table: "_Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK__student",
                table: "_student");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Course",
                table: "_Course");

            migrationBuilder.RenameTable(
                name: "_Teacher",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "_student",
                newName: "student");

            migrationBuilder.RenameTable(
                name: "_Course",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX__student_courseId",
                table: "student",
                newName: "IX_student_courseId");

            migrationBuilder.RenameIndex(
                name: "IX__Course_teacherId",
                table: "Course",
                newName: "IX_Course_teacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student",
                table: "student",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_teacherId",
                table: "Course",
                column: "teacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_Course_courseId",
                table: "student",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_teacherId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_student_Course_courseId",
                table: "student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student",
                table: "student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "_Teacher");

            migrationBuilder.RenameTable(
                name: "student",
                newName: "_student");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "_Course");

            migrationBuilder.RenameIndex(
                name: "IX_student_courseId",
                table: "_student",
                newName: "IX__student_courseId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_teacherId",
                table: "_Course",
                newName: "IX__Course_teacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Teacher",
                table: "_Teacher",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__student",
                table: "_student",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Course",
                table: "_Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK__Course__Teacher_teacherId",
                table: "_Course",
                column: "teacherId",
                principalTable: "_Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__student__Course_courseId",
                table: "_student",
                column: "courseId",
                principalTable: "_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
