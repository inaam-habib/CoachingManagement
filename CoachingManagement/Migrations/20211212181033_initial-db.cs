using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachingManagement.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teacher", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "_Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK__Course__Teacher_teacherId",
                        column: x => x.teacherId,
                        principalTable: "_Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK__student__Course_courseId",
                        column: x => x.courseId,
                        principalTable: "_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__Course_teacherId",
                table: "_Course",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX__student_courseId",
                table: "_student",
                column: "courseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_student");

            migrationBuilder.DropTable(
                name: "_Course");

            migrationBuilder.DropTable(
                name: "_Teacher");
        }
    }
}
