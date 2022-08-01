using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projectapi.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aadhar_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    panId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    voterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salarySlip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saleAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    propertyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estimatedCost = table.Column<long>(type: "bigint", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    retire = table.Column<int>(type: "int", nullable: false),
                    propertyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    tenure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No_of_installments = table.Column<int>(type: "int", nullable: false),
                    Reference_Number = table.Column<long>(type: "bigint", nullable: false),
                    loanAmount = table.Column<long>(type: "bigint", nullable: false),
                    Elgible_Amount = table.Column<int>(type: "int", nullable: false),
                    ROI = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phNumber = table.Column<long>(type: "bigint", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adharNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    panId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLoan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Next_Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remaining_Amount = table.Column<int>(type: "int", nullable: false),
                    Date_Sanctioned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanDetailsID = table.Column<int>(type: "int", nullable: true),
                    UserBankID = table.Column<int>(type: "int", nullable: true),
                    IncomeDetailsID = table.Column<int>(type: "int", nullable: true),
                    DocumentDetailsID = table.Column<int>(type: "int", nullable: true),
                    UserDetailsId = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_UserLoan_UserTable_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserTable",
                        principalColumn: "Id",
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
                    UserTableId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_UserAccountTable_UserTable_UserTableId",
                        column: x => x.UserTableId,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountTable_UserLoanID",
                table: "UserAccountTable",
                column: "UserLoanID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountTable_UserTableId",
                table: "UserAccountTable",
                column: "UserTableId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserLoan_UserDetailsId",
                table: "UserLoan",
                column: "UserDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccountTable");

            migrationBuilder.DropTable(
                name: "UserLoan");

            migrationBuilder.DropTable(
                name: "DocumentDetails");

            migrationBuilder.DropTable(
                name: "IncomeDetails");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "UserBankDetails");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}
