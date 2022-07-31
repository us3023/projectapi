using Microsoft.EntityFrameworkCore.Migrations;

namespace projectapi.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccountTable_UserTable_UserTableID",
                table: "UserAccountTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLoan_UserTable_UserDetailsID",
                table: "UserLoan");

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
                name: "Tenure_of_payment",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "Timeperiod",
                table: "LoanDetails");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "UserTable",
                newName: "nationality");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "UserTable",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserTable",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Phone_Number",
                table: "UserTable",
                newName: "phNumber");

            migrationBuilder.RenameColumn(
                name: "Middle_Name",
                table: "UserTable",
                newName: "panId");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "UserTable",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "UserTable",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Emai_ID",
                table: "UserTable",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "UserDetailsID",
                table: "UserLoan",
                newName: "UserDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoan_UserDetailsID",
                table: "UserLoan",
                newName: "IX_UserLoan_UserDetailsId");

            migrationBuilder.RenameColumn(
                name: "UserTableID",
                table: "UserAccountTable",
                newName: "UserTableId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccountTable_UserTableID",
                table: "UserAccountTable",
                newName: "IX_UserAccountTable_UserTableId");

            migrationBuilder.RenameColumn(
                name: "Retirement_Age",
                table: "IncomeDetails",
                newName: "retire");

            migrationBuilder.RenameColumn(
                name: "Property_Name",
                table: "IncomeDetails",
                newName: "propertyName");

            migrationBuilder.RenameColumn(
                name: "Prop_Location",
                table: "IncomeDetails",
                newName: "propertyLocation");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "IncomeDetails",
                newName: "employmentType");

            migrationBuilder.RenameColumn(
                name: "Estimated_Cost",
                table: "IncomeDetails",
                newName: "estimatedCost");

            migrationBuilder.RenameColumn(
                name: "Emp_Type",
                table: "IncomeDetails",
                newName: "employerName");

            migrationBuilder.RenameColumn(
                name: "Current_Sallary",
                table: "IncomeDetails",
                newName: "Current_Salary");

            migrationBuilder.RenameColumn(
                name: "Voter_ID",
                table: "DocumentDetails",
                newName: "voterId");

            migrationBuilder.RenameColumn(
                name: "Pay_Slip",
                table: "DocumentDetails",
                newName: "saleAgreement");

            migrationBuilder.RenameColumn(
                name: "PAN",
                table: "DocumentDetails",
                newName: "salarySlip");

            migrationBuilder.RenameColumn(
                name: "Adhar_Number",
                table: "DocumentDetails",
                newName: "panId");

            migrationBuilder.AddColumn<string>(
                name: "adharNo",
                table: "UserTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emailId",
                table: "UserTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "loanAmount",
                table: "LoanDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "tenure",
                table: "LoanDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aadhar_Number",
                table: "DocumentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccountTable_UserTable_UserTableId",
                table: "UserAccountTable",
                column: "UserTableId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoan_UserTable_UserDetailsId",
                table: "UserLoan",
                column: "UserDetailsId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccountTable_UserTable_UserTableId",
                table: "UserAccountTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLoan_UserTable_UserDetailsId",
                table: "UserLoan");

            migrationBuilder.DropColumn(
                name: "adharNo",
                table: "UserTable");

            migrationBuilder.DropColumn(
                name: "emailId",
                table: "UserTable");

            migrationBuilder.DropColumn(
                name: "loanAmount",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "tenure",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "Aadhar_Number",
                table: "DocumentDetails");

            migrationBuilder.RenameColumn(
                name: "nationality",
                table: "UserTable",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "UserTable",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserTable",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "phNumber",
                table: "UserTable",
                newName: "Phone_Number");

            migrationBuilder.RenameColumn(
                name: "panId",
                table: "UserTable",
                newName: "Middle_Name");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "UserTable",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "UserTable",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "UserTable",
                newName: "Emai_ID");

            migrationBuilder.RenameColumn(
                name: "UserDetailsId",
                table: "UserLoan",
                newName: "UserDetailsID");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoan_UserDetailsId",
                table: "UserLoan",
                newName: "IX_UserLoan_UserDetailsID");

            migrationBuilder.RenameColumn(
                name: "UserTableId",
                table: "UserAccountTable",
                newName: "UserTableID");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccountTable_UserTableId",
                table: "UserAccountTable",
                newName: "IX_UserAccountTable_UserTableID");

            migrationBuilder.RenameColumn(
                name: "retire",
                table: "IncomeDetails",
                newName: "Retirement_Age");

            migrationBuilder.RenameColumn(
                name: "propertyName",
                table: "IncomeDetails",
                newName: "Property_Name");

            migrationBuilder.RenameColumn(
                name: "propertyLocation",
                table: "IncomeDetails",
                newName: "Prop_Location");

            migrationBuilder.RenameColumn(
                name: "estimatedCost",
                table: "IncomeDetails",
                newName: "Estimated_Cost");

            migrationBuilder.RenameColumn(
                name: "employmentType",
                table: "IncomeDetails",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "employerName",
                table: "IncomeDetails",
                newName: "Emp_Type");

            migrationBuilder.RenameColumn(
                name: "Current_Salary",
                table: "IncomeDetails",
                newName: "Current_Sallary");

            migrationBuilder.RenameColumn(
                name: "voterId",
                table: "DocumentDetails",
                newName: "Voter_ID");

            migrationBuilder.RenameColumn(
                name: "saleAgreement",
                table: "DocumentDetails",
                newName: "Pay_Slip");

            migrationBuilder.RenameColumn(
                name: "salarySlip",
                table: "DocumentDetails",
                newName: "PAN");

            migrationBuilder.RenameColumn(
                name: "panId",
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
                name: "Tenure_of_payment",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Timeperiod",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccountTable_UserTable_UserTableID",
                table: "UserAccountTable",
                column: "UserTableID",
                principalTable: "UserTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoan_UserTable_UserDetailsID",
                table: "UserLoan",
                column: "UserDetailsID",
                principalTable: "UserTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
