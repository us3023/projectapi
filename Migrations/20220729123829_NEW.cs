using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projectapi.Migrations
{
    public partial class NEW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adhar_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voter_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pay_Slip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reg_Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collateral = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IncomeDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Current_Sallary = table.Column<long>(type: "bigint", nullable: false),
                    Prop_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estimated_Cost = table.Column<long>(type: "bigint", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emp_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Retirement_Age = table.Column<int>(type: "int", nullable: false),
                    Property_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount_Required = table.Column<long>(type: "bigint", nullable: false),
                    Tenure_of_payment = table.Column<int>(type: "int", nullable: false),
                    No_of_installments = table.Column<int>(type: "int", nullable: false),
                    Reference_Number = table.Column<long>(type: "bigint", nullable: false),
                    Elgible_Amount = table.Column<int>(type: "int", nullable: false),
                    Timeperiod = table.Column<int>(type: "int", nullable: false),
                    ROI = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserBankDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Bank_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBankDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middle_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emai_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<long>(type: "bigint", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserLoan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Loan_ID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Next_Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remaining_Amount = table.Column<int>(type: "int", nullable: false),
                    Date_Sanctioned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanDetailsID = table.Column<int>(type: "int", nullable: true),
                    UserBankID = table.Column<int>(type: "int", nullable: true),
                    IncomeDetailsID = table.Column<int>(type: "int", nullable: true),
                    DocumentDetailsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserLoan_DocumentDetails_DocumentDetailsID",
                        column: x => x.DocumentDetailsID,
                        principalTable: "DocumentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLoan_IncomeDetails_IncomeDetailsID",
                        column: x => x.IncomeDetailsID,
                        principalTable: "IncomeDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLoan_LoanDetails_LoanDetailsID",
                        column: x => x.LoanDetailsID,
                        principalTable: "LoanDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLoan_UserBankDetails_UserBankID",
                        column: x => x.UserBankID,
                        principalTable: "UserBankDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTableID = table.Column<int>(type: "int", nullable: true),
                    UserLoanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAccountTable_UserLoan_UserLoanID",
                        column: x => x.UserLoanID,
                        principalTable: "UserLoan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccountTable_UserTable_UserTableID",
                        column: x => x.UserTableID,
                        principalTable: "UserTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountTable_UserLoanID",
                table: "UserAccountTable",
                column: "UserLoanID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountTable_UserTableID",
                table: "UserAccountTable",
                column: "UserTableID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoan_DocumentDetailsID",
                table: "UserLoan",
                column: "DocumentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoan_IncomeDetailsID",
                table: "UserLoan",
                column: "IncomeDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoan_LoanDetailsID",
                table: "UserLoan",
                column: "LoanDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoan_UserBankID",
                table: "UserLoan",
                column: "UserBankID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccountTable");

            migrationBuilder.DropTable(
                name: "UserLoan");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "DocumentDetails");

            migrationBuilder.DropTable(
                name: "IncomeDetails");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "UserBankDetails");
        }
    }
}
