using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Places_API.Migrations
{
    /// <inheritdoc />
    public partial class FinalModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StarRating",
                table: "Places",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "StarRating",
                table: "Places",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 1);
        }
    }
}
