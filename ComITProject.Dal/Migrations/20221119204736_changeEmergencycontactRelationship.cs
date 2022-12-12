using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComITProject.Dal.Migrations
{
    /// <inheritdoc />
    public partial class changeEmergencycontactRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmergencyContact_PatientId",
                table: "EmergencyContact");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PatientId",
                table: "EmergencyContact",
                column: "PatientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmergencyContact_PatientId",
                table: "EmergencyContact");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PatientId",
                table: "EmergencyContact",
                column: "PatientId");
        }
    }
}
