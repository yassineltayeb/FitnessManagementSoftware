using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                                name: "AvailbleSpaces",
                                table: "CoachClasses",
                                newName: "AvailableSpaces");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                                name: "AvailableSpaces",
                                table: "CoachClasses",
                                newName: "AvailbleSpaces");
        }
    }
}
