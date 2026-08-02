using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pos.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Optimize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modified_datetime",
                table: "user_account",
                newName: "modified_at");

            migrationBuilder.RenameColumn(
                name: "create_datetime",
                table: "user_account",
                newName: "create_at");

            migrationBuilder.RenameColumn(
                name: "modified_datetime",
                table: "company",
                newName: "modified_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modified_at",
                table: "user_account",
                newName: "modified_datetime");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "user_account",
                newName: "create_datetime");

            migrationBuilder.RenameColumn(
                name: "modified_at",
                table: "company",
                newName: "modified_datetime");
        }
    }
}
