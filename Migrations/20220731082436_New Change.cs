using Microsoft.EntityFrameworkCore.Migrations;

namespace projectapi.Migrations
{
    public partial class NewChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "LoanDetails");

            migrationBuilder.AddColumn<int>(
                name: "UserDetailsID",
                table: "UserLoan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoan_UserDetailsID",
                table: "UserLoan",
                column: "UserDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoan_UserTable_UserDetailsID",
                table: "UserLoan",
                column: "UserDetailsID",
                principalTable: "UserTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoan_UserTable_UserDetailsID",
                table: "UserLoan");

            migrationBuilder.DropIndex(
                name: "IX_UserLoan_UserDetailsID",
                table: "UserLoan");

            migrationBuilder.DropColumn(
                name: "UserDetailsID",
                table: "UserLoan");

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
