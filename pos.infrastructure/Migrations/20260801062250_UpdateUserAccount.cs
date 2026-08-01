using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pos.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bit_super_admin",
                table: "user_account",
                newName: "is_super_admin");

            migrationBuilder.RenameColumn(
                name: "bit_blocked",
                table: "user_account",
                newName: "is_blocked");

            migrationBuilder.RenameColumn(
                name: "bit_active",
                table: "user_account",
                newName: "is_active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_super_admin",
                table: "user_account",
                newName: "bit_super_admin");

            migrationBuilder.RenameColumn(
                name: "is_blocked",
                table: "user_account",
                newName: "bit_blocked");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "user_account",
                newName: "bit_active");
        }
    }
}
