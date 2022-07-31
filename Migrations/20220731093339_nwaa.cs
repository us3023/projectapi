using Microsoft.EntityFrameworkCore.Migrations;

namespace projectapi.Migrations
{
    public partial class nwaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Loan_ID",
                table: "UserLoan");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "UserLoan");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "UserBankDetails");

            migrationBuilder.DropColumn(
                name: "Timeperiod",
                table: "LoanDetails");

            migrationBuilder.RenameColumn(
                name: "Current_Sallary",
                table: "IncomeDetails",
                newName: "Current_Salary");

            migrationBuilder.RenameColumn(
                name: "Adhar_Number",
                table: "DocumentDetails",
                newName: "Aadhar_Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Current_Salary",
                table: "IncomeDetails",
                newName: "Current_Sallary");

            migrationBuilder.RenameColumn(
                name: "Aadhar_Number",
                table: "DocumentDetails",
                newName: "Adhar_Number");

            migrationBuilder.AddColumn<int>(
                name: "Loan_ID",
                table: "UserLoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "UserLoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "UserBankDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Timeperiod",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
