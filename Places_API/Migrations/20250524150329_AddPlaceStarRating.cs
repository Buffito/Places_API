using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Places_API.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaceStarRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StarRating",
                table: "Places",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarRating",
                table: "Places");
        }
    }
}
