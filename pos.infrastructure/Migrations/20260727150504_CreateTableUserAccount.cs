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
                name: "User_Account",
                columns: table => new
                {
                    User_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID_GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password_Hash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    User_PIN_Hash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Bit_Super_Admin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Staff_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email_Address = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Mobile_No_Country_Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Mobile_No = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Bit_Blocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Bit_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created_By = table.Column<long>(type: "bigint", nullable: false),
                    Created_DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_By = table.Column<long>(type: "bigint", nullable: true),
                    Modified_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Account", x => x.User_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Account_User_ID_GUID",
                table: "User_Account",
                column: "User_ID_GUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Account_User_Name",
                table: "User_Account",
                column: "User_Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Account");
        }
    }
}
