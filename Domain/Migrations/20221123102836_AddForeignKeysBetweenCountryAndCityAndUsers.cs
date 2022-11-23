using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeysBetweenCountryAndCityAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_CityId",
                table: "Members",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CountryId",
                table: "Members",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CityId",
                table: "Coaches",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CountryId",
                table: "Coaches",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Cities_CityId",
                table: "Coaches",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Countries_CountryId",
                table: "Coaches",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Cities_CityId",
                table: "Members",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Countries_CountryId",
                table: "Members",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Cities_CityId",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Countries_CountryId",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Cities_CityId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Countries_CountryId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_CityId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_CountryId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_CityId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_CountryId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Coaches");
        }
    }
}
