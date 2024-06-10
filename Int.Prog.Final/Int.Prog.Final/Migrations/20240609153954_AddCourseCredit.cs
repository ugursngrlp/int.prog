using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Int.Prog.Final.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseCredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Credit",
                table: "tblCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "tblCourses");
        }
    }
}
