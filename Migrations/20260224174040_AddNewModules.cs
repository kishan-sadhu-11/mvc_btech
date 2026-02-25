using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc_btech.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    exam_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false),
                    exam_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.exam_id);
                });

            migrationBuilder.CreateTable(
                name: "fees",
                columns: table => new
                {
                    fees_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    paid_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    remaining_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fees", x => x.fees_id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.teacher_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "fees");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
