using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaccoManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class saccos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Passkey = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ApiUser = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ApiPassword = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ConsumerKey = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ConsumerSecret = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ShortCode = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(NULL)"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_transactions = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ApiTable__3214EC279AB0239B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApiTransactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ApiUser = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    ShortCode = table.Column<int>(type: "int", nullable: true),
                    TransactionCode = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CheckoutID = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ConversationID = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Recipient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StatusCode = table.Column<int>(type: "int", nullable: true),
                    Request = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ApiTrans__3214EC27F0CCE46D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CHEQUES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MemberNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChequeNo = table.Column<string>(type: "nvarchar(230)", maxLength: 230, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    BalForward = table.Column<decimal>(type: "money", nullable: true),
                    ProcessingFee = table.Column<decimal>(type: "money", nullable: true),
                    IntAmount = table.Column<decimal>(type: "money", nullable: true),
                    IntrOwed = table.Column<decimal>(type: "money", nullable: false),
                    CollectorID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CollectorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateIssued = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClerkStaffNo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ClerkName = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Reasons = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Remarks = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    AmountIssued = table.Column<decimal>(type: "money", nullable: true),
                    firstdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Premium = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    offsetamount = table.Column<decimal>(type: "money", nullable: false),
                    amountinword = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, defaultValue: ""),
                    voucherno = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, defaultValue: ""),
                    voucheramount = table.Column<decimal>(type: "money", nullable: false),
                    refloan = table.Column<bool>(type: "bit", nullable: false),
                    paymethod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: ""),
                    Balance = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    TransactionNo = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false, defaultValue: "BeforeTransactions"),
                    OrgAmt = table.Column<decimal>(type: "money", nullable: false),
                    LoanAcc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "A007"),
                    ContraAcc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "A001"),
                    PremiumAcc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "E013"),
                    dregard = table.Column<int>(type: "int", nullable: false),
                    PaidBf = table.Column<decimal>(type: "money", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHEQUES_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Othername = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IDNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PIN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PIN_STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Secret_Word = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    unsubscribe = table.Column<int>(type: "int", nullable: true),
                    User_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuditTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Acs = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Subscription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubscriptionPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CIGCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubCounty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Village = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    unitcode = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contactperson = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NoYears = table.Column<int>(type: "int", nullable: true),
                    NoEmployees = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "(getdate())"),
                    Capital = table.Column<decimal>(type: "money", nullable: true),
                    project = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoopTransactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TransactionID = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ResultCode = table.Column<int>(type: "int", nullable: false),
                    ResultMessage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ConversationID = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ShortCode = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemberNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OriginatorConversationID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MerchantRequestID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CheckoutRequestID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ENDMAIN",
                columns: table => new
                {
                    LoanNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinuteNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AmtApproved = table.Column<decimal>(type: "money", nullable: false),
                    Accepted = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ChairSigned = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SecSigned = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    MembSigned = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Reasons = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    TransactionNo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDMAIN", x => x.LoanNo);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedgers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    source = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Debits = table.Column<decimal>(type: "money", nullable: true),
                    Credits = table.Column<decimal>(type: "money", nullable: true),
                    AccBal = table.Column<decimal>(type: "money", nullable: true),
                    Chequeno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    GLName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GLTRANSACTIONS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    DrAccNo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, defaultValue: ""),
                    CrAccNo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, defaultValue: ""),
                    Temp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    DocumentNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    Source = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransDescript = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    AuditID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, defaultValue: "Admin"),
                    Cash = table.Column<int>(type: "int", nullable: false),
                    doc_posted = table.Column<int>(type: "int", nullable: false),
                    ChequeNo = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    dregard = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Recon = table.Column<bool>(type: "bit", nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: true),
                    Module = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, defaultValue: "BOSASaccos"),
                    ReconId = table.Column<int>(type: "int", nullable: false),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LOANBAL",
                columns: table => new
                {
                    LoanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Companycode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    IntrOwed = table.Column<decimal>(type: "money", nullable: false),
                    Installments = table.Column<decimal>(type: "money", nullable: true),
                    IntrOwed2 = table.Column<decimal>(type: "money", nullable: false),
                    FirstDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RepayRate = table.Column<decimal>(type: "money", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    duedate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    intrCharged = table.Column<decimal>(type: "money", nullable: false),
                    Interest = table.Column<decimal>(type: "money", nullable: false),
                    Penalty = table.Column<decimal>(type: "money", nullable: false),
                    RepayRate2 = table.Column<decimal>(type: "money", nullable: true),
                    RepayMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cleared = table.Column<bool>(type: "bit", nullable: false),
                    AutoCalc = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IntrAmount = table.Column<decimal>(type: "money", nullable: false),
                    RepayPeriod = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IntBalance = table.Column<decimal>(type: "money", nullable: false),
                    CategoryCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    InterestAccrued = table.Column<decimal>(type: "money", nullable: false),
                    Defaulter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
                    Processdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Receiptno = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Cease = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nextduedate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Month = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepayMode = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    Gperiod = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))"),
                    ApiKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Run = table.Column<long>(type: "bigint", nullable: true, defaultValue: 0L),
                    SerialNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOANBAL", x => new { x.Companycode, x.LoanNo });
                });

            migrationBuilder.CreateTable(
                name: "LOANGUAR",
                columns: table => new
                {
                    MemberNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LoanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    Balance = table.Column<decimal>(type: "money", nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    collateral = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    transfered = table.Column<bool>(type: "bit", nullable: false),
                    Transdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FullNames = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true, defaultValue: ""),
                    tguaranto = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LOANS",
                columns: table => new
                {
                    LoanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LoanCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApplicDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LoanAmt = table.Column<decimal>(type: "money", nullable: true),
                    RepayPeriod = table.Column<int>(type: "int", nullable: true),
                    PremiumPayable = table.Column<decimal>(type: "money", nullable: true),
                    PHCF = table.Column<decimal>(type: "money", nullable: true),
                    TotalPremium = table.Column<decimal>(type: "money", nullable: true),
                    IdNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobGrp = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BasicSalary = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    WitMemberNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WitSigned = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SupMemberNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SupSigned = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddSecurity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Insurance = table.Column<decimal>(type: "money", nullable: true),
                    InsPercent = table.Column<decimal>(type: "money", nullable: true),
                    InsCalcType = table.Column<int>(type: "int", nullable: true),
                    Posted = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    aamount = table.Column<decimal>(type: "money", nullable: true),
                    Guaranteed = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Cshares = table.Column<decimal>(type: "money", nullable: true),
                    MaxLoanamt = table.Column<decimal>(type: "money", nullable: true),
                    Grosspay = table.Column<decimal>(type: "money", nullable: true),
                    Refinancing = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Loancount = table.Column<long>(type: "bigint", nullable: true),
                    bridging = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    RepayMethod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: ""),
                    Interest = table.Column<decimal>(type: "money", nullable: true, defaultValue: 12m),
                    TransactionNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValue: "BAL B/F"),
                    Status = table.Column<int>(type: "int", nullable: true, defaultValue: 4),
                    Sourceofrepayment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: ""),
                    repayrate = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    Sharecapital = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    rescheduledate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gperiod = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Run = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Run2 = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    ApiKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOANS", x => new { x.CompanyCode, x.LoanNo });
                });

            migrationBuilder.CreateTable(
                name: "LOANTYPE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    LoanType = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ValueChain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoanProduct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    MinimumPaidForBridging = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)50),
                    MinimumPaidForTopup = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)30),
                    LoanAcc = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    InterestAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OverpaymentAcc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoanOverpaymentAcc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PenaltyAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: ""),
                    SchemeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    RepayPeriod = table.Column<int>(type: "int", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaxAmount = table.Column<decimal>(type: "money", nullable: true),
                    Guarantor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    useintRange = table.Column<bool>(type: "bit", nullable: true),
                    accno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IntAccno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EarningRation = table.Column<decimal>(type: "money", nullable: true),
                    Penalty = table.Column<bool>(type: "bit", nullable: false),
                    DefaultLoanno = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NSSF = table.Column<decimal>(type: "money", nullable: true),
                    bankloan = table.Column<decimal>(type: "money", nullable: true),
                    OtherDeduct = table.Column<decimal>(type: "money", nullable: true),
                    priority = table.Column<int>(type: "int", nullable: true),
                    MaxLoans = table.Column<int>(type: "int", nullable: true),
                    contraAccount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "0"),
                    Bridging = table.Column<bool>(type: "bit", nullable: false),
                    Processingfee = table.Column<decimal>(type: "money", nullable: true),
                    ContraAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GracePeriod = table.Column<int>(type: "int", nullable: false),
                    Repaymethod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "RBAL"),
                    PremiumAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PremiumContraAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Bridgefees = table.Column<double>(type: "float", nullable: true),
                    periodrepaid = table.Column<int>(type: "int", nullable: true),
                    WaitingPeriod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AccruedAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "((0))"),
                    PPAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "L041"),
                    MDTEI = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)7),
                    intrecovery = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "periodic"),
                    isMain = table.Column<bool>(type: "bit", nullable: false),
                    selfGuarantee = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ReceivableAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "((602012))"),
                    ApiKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isFIMG = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('0')"),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileLoan = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    MobileCreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MobileCreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOANTYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MEMBERS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StaffNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IDNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(555)", maxLength: 555, nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(555)", maxLength: 555, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    Employer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Dept = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Terms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PresentAddr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OfficeTelNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HomeAddr = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    HomeTelNo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    RegFee = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    InitShares = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    AsAtDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MonthlyContr = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    ApplicDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EffectDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Signed = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Accepted = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Withdrawn = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Province = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    District = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Station = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
                    CIGCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PIN = table.Column<string>(type: "varchar(53)", unicode: false, maxLength: 53, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareCap = table.Column<decimal>(type: "money", nullable: true),
                    BankCode = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Bname = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    E_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    posted = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    initsharesTransfered = table.Column<decimal>(type: "money", nullable: true),
                    Transferdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LoanBalance = table.Column<decimal>(type: "money", nullable: true),
                    InterestBalance = table.Column<decimal>(type: "money", nullable: true),
                    FormFilled = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    accno = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    memberwitrawaldate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Dormant = table.Column<int>(type: "int", nullable: true),
                    MemberDescription = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true, defaultValue: "ORDINARY"),
                    email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MobileNo = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    AgentId = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    PhoneNo = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    Entrance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "False"),
                    status = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)1),
                    mstatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    MembershipType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Run = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProfileString = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEMBERS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "REPAY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentNo = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    Principal = table.Column<decimal>(type: "money", nullable: true),
                    Interest = table.Column<decimal>(type: "money", nullable: true),
                    IntrCharged = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    IntrOwed = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    IntrAccrued = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    Penalty = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    LoanBalance = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    ReceiptNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    chequeno = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RepayRate = table.Column<decimal>(type: "money", nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: true),
                    Posted = table.Column<bool>(type: "bit", nullable: true),
                    Accrued = table.Column<bool>(type: "bit", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ch = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    nextduedate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    RepayId = table.Column<long>(type: "bigint", nullable: true),
                    Transby = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    IntBalance = table.Column<decimal>(type: "money", nullable: true),
                    Loancode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Interestaccrued = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    MRNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MRCleared = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Transno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TransDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BridgeInterest = table.Column<decimal>(type: "money", nullable: true),
                    BrgLoan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Statementdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LoanAcc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    InterestAcc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContraAcc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cash = table.Column<int>(type: "int", nullable: true),
                    CashBookDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    dregard = table.Column<int>(type: "int", nullable: false),
                    offs = table.Column<int>(type: "int", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Run = table.Column<long>(type: "bigint", nullable: true, defaultValue: 0L),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SHARES",
                columns: table => new
                {
                    MemberNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TotalShares = table.Column<decimal>(type: "money", nullable: true),
                    TransDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastDivDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    loanbal = table.Column<decimal>(type: "money", nullable: true),
                    sharescode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Statementshares = table.Column<decimal>(type: "money", nullable: true),
                    Initshares = table.Column<decimal>(type: "money", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sharetype",
                columns: table => new
                {
                    SharesCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SharesType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SharesAcc = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    PlacePeriod = table.Column<int>(type: "int", nullable: true),
                    LoanToShareRatio = table.Column<float>(type: "real", nullable: true),
                    Issharecapital = table.Column<int>(type: "int", nullable: true),
                    Interest = table.Column<decimal>(type: "money", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaxAmount = table.Column<decimal>(type: "money", nullable: true),
                    Guarantor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    accno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    shareboost = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsMainShares = table.Column<bool>(type: "bit", nullable: false),
                    UsedToGuarantee = table.Column<bool>(type: "bit", nullable: false),
                    ContraAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UsedToOffset = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Withdrawable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    loanquaranto = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    MinAmount = table.Column<decimal>(type: "money", nullable: false),
                    PPAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "L041"),
                    LowerLimit = table.Column<decimal>(type: "money", nullable: false),
                    ElseRatio = table.Column<decimal>(type: "money", nullable: false),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sharetype", x => x.SharesCode);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    SystemUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.SystemUserId);
                });

            migrationBuilder.CreateTable(
                name: "Transaction_detail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TransactionID = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ResultCode = table.Column<int>(type: "int", nullable: false),
                    ResultMessage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ConversationID = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ShortCode = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(NULL)"),
                    MemberNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OriginatorConversationID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MerchantRequestID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CheckoutRequestID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__3214EC2714D2C3C1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "(getdate())"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AuditId = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    transDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "Active"),
                    CompanyCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<string>(type: "nchar(80)", fixedLength: true, maxLength: 80, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transactions2",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Companycode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValueSql: "(getdate())"),
                    ReceiptNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    ContributionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepositedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AuditId = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "Active"),
                    RunE = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    SessionId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts1",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserLoginID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CIGcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PassExpire = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    SUPERUSER = table.Column<long>(type: "bigint", nullable: true),
                    MemberNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssignGl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DepCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    levels = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Authorize = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubCounty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sign = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    expirydate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    userstatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    passwordStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    euser = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    vendor_ID = table.Column<long>(type: "bigint", nullable: true),
                    count = table.Column<long>(type: "bigint", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    branchcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FailedAttempts = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    IsLocked = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, defaultValueSql: "(NULL)"),
                    PhoneNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Wicci_Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Othername = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IDNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PIN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PIN_STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Secret_Word = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    unsubscribe = table.Column<int>(type: "int", nullable: true),
                    User_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuditTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Acs = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Subscription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CONTRIB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StaffNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContrDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DepositedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "(getdate())"),
                    RefNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    ShareBal = table.Column<decimal>(type: "money", nullable: true),
                    TransBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChequeNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReceiptNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Locked = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Posted = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    schemecode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TransferDesc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MrCleared = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    mrno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TransNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: ""),
                    Offset = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    TransDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SharesAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContraAcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CashBookdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    dregard = table.Column<int>(type: "int", nullable: true),
                    offs = table.Column<int>(type: "int", nullable: true),
                    Sharescode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Run = table.Column<long>(type: "bigint", nullable: true, defaultValue: 1L),
                    Run2 = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTRIB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTRIB_sharetype",
                        column: x => x.Sharescode,
                        principalTable: "sharetype",
                        principalColumn: "SharesCode");
                });

            migrationBuilder.CreateTable(
                name: "CONTRIB_SHARES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOCAL_ID = table.Column<int>(type: "int", nullable: true),
                    MemberNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LoanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContrDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DepositedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ShareCapitalAmount = table.Column<decimal>(type: "money", nullable: true),
                    DepositsAmount = table.Column<decimal>(type: "money", nullable: true),
                    PassBookAmount = table.Column<decimal>(type: "money", nullable: true),
                    Donor = table.Column<decimal>(type: "money", nullable: true),
                    LoanAmount = table.Column<decimal>(type: "money", nullable: true),
                    RegFeeAmount = table.Column<decimal>(type: "money", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    sharescode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTRIB_SHARES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTRIB_SHARES_sharetype",
                        column: x => x.sharescode,
                        principalTable: "sharetype",
                        principalColumn: "SharesCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTRIB_Sharescode",
                table: "CONTRIB",
                column: "Sharescode");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRIB_SHARES_sharescode",
                table: "CONTRIB_SHARES",
                column: "sharescode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiTable");

            migrationBuilder.DropTable(
                name: "ApiTransactions");

            migrationBuilder.DropTable(
                name: "CHEQUES");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "COMPANY");

            migrationBuilder.DropTable(
                name: "CONTRIB");

            migrationBuilder.DropTable(
                name: "CONTRIB_SHARES");

            migrationBuilder.DropTable(
                name: "CoopTransactions");

            migrationBuilder.DropTable(
                name: "ENDMAIN");

            migrationBuilder.DropTable(
                name: "GeneralLedgers");

            migrationBuilder.DropTable(
                name: "GLTRANSACTIONS");

            migrationBuilder.DropTable(
                name: "LOANBAL");

            migrationBuilder.DropTable(
                name: "LOANGUAR");

            migrationBuilder.DropTable(
                name: "LOANS");

            migrationBuilder.DropTable(
                name: "LOANTYPE");

            migrationBuilder.DropTable(
                name: "MEMBERS");

            migrationBuilder.DropTable(
                name: "REPAY");

            migrationBuilder.DropTable(
                name: "SHARES");

            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropTable(
                name: "Transaction_detail");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Transactions2");

            migrationBuilder.DropTable(
                name: "UserAccounts1");

            migrationBuilder.DropTable(
                name: "Wicci_Clients");

            migrationBuilder.DropTable(
                name: "sharetype");
        }
    }
}
