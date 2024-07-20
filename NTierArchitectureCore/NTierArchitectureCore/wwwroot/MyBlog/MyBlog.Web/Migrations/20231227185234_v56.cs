using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Web.Migrations
{
    /// <inheritdoc />
    public partial class v56 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "CreatedDAte",
                table: "Projects",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Assignments",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Projects",
                newName: "CreatedDAte");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Assignments",
                newName: "status");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
