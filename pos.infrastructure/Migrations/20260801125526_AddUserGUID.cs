using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pos.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserGUID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_account_company_id",
                table: "user_account");

            migrationBuilder.AddColumn<Guid>(
                name: "user_guid",
                table: "user_account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.CreateIndex(
                name: "ix_user_account_user_guid",
                table: "user_account",
                column: "user_guid")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_account_user_guid",
                table: "user_account");

            migrationBuilder.DropColumn(
                name: "user_guid",
                table: "user_account");

            migrationBuilder.CreateIndex(
                name: "ix_user_account_company_id",
                table: "user_account",
                column: "company_id");
        }
    }
}
