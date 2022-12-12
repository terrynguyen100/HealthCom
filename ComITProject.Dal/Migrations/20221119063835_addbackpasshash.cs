using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComITProject.Dal.Migrations
{
    /// <inheritdoc />
    public partial class addbackpasshash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AspNetUsers");
        }
    }
}
