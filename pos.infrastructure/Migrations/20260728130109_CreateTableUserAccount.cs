using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pos.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_account",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    user_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    password_hash = table.Column<string>(type: "varchar(256)", nullable: false),
                    user_pin_hash = table.Column<string>(type: "varchar(256)", nullable: false),
                    bit_super_admin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    staff_name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    email_address = table.Column<string>(type: "varchar(254)", nullable: true),
                    mobile_no_country_code = table.Column<string>(type: "varchar(4)", nullable: true),
                    mobile_no = table.Column<string>(type: "varchar(15)", nullable: true),
                    bit_blocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    bit_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    create_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_account", x => x.user_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_account_company_id",
                table: "user_account",
                column: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_account");
        }
    }
}
