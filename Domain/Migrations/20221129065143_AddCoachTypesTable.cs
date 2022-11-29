using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddCoachTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoachTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoachesTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<long>(type: "bigint", nullable: false),
                    CoachTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachesTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoachesTypes_CoachTypes_CoachTypeId",
                        column: x => x.CoachTypeId,
                        principalTable: "CoachTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachesTypes_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoachTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gym Instructor" },
                    { 2, "Bootcamp Instructor" },
                    { 3, "Crossfit Instructor" },
                    { 4, "Group Exercise Instructor" },
                    { 5, "Mobile Personal Trainer" },
                    { 6, "Physique Trainer" },
                    { 7, "Performance Personal Trainer" },
                    { 8, "Lifestyle Personal Trainer" },
                    { 9, "Sports Trainer" },
                    { 10, "Health Coach" },
                    { 11, "Cardio Trainer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachesTypes_CoachId",
                table: "CoachesTypes",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachesTypes_CoachTypeId",
                table: "CoachesTypes",
                column: "CoachTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachesTypes");

            migrationBuilder.DropTable(
                name: "CoachTypes");
        }
    }
}
