using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SaccoManagementSystem.Models.DB;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SystemUsers> SystemUsers { get; set; }
    public virtual DbSet<ApiTable> ApiTables { get; set; }

    public virtual DbSet<ApiTransaction> ApiTransactions { get; set; }

    public virtual DbSet<Cheque> Cheques { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Contrib> Contribs { get; set; }

    public virtual DbSet<ContribShare> ContribShares { get; set; }

    public virtual DbSet<CoopTransaction> CoopTransactions { get; set; }

    public virtual DbSet<Endmain> Endmains { get; set; }

    public virtual DbSet<GeneralLedger> GeneralLedgers { get; set; }

    public virtual DbSet<Gltransaction> Gltransactions { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Loanbal> Loanbals { get; set; }

    public virtual DbSet<Loanguar> Loanguars { get; set; }

    public virtual DbSet<Loantype> Loantypes { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Repay> Repays { get; set; }

    public virtual DbSet<Share> Shares { get; set; }

    public virtual DbSet<Sharetype> Sharetypes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    public virtual DbSet<Transactions2> Transactions2s { get; set; }

    public virtual DbSet<UserAccounts1> UserAccounts1s { get; set; }

    public virtual DbSet<WicciClient> WicciClients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=COMPTECH;Database=BOSASaccos;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;User Id=kibet;Password=kibet123;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiTable__3214EC279AB0239B");

            entity.ToTable("ApiTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNo).HasMaxLength(250);
            entity.Property(e => e.ApiPassword).HasMaxLength(2000);
            entity.Property(e => e.ApiUser)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Channel).HasMaxLength(200);
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConsumerKey).HasMaxLength(2000);
            entity.Property(e => e.ConsumerSecret).HasMaxLength(2000);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Passkey)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalTransactions).HasColumnName("total_transactions");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ApiTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiTrans__3214EC27F0CCE46D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ApiUser)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CheckoutId)
                .HasMaxLength(300)
                .HasColumnName("CheckoutID");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ConversationId)
                .HasMaxLength(300)
                .HasColumnName("ConversationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.LoanNo).HasMaxLength(200);
            entity.Property(e => e.Recipient).HasMaxLength(100);
            entity.Property(e => e.Request)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCode)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Cheque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CHEQUES_1");

            entity.ToTable("CHEQUES");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AmountIssued).HasColumnType("money");
            entity.Property(e => e.Amountinword)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("amountinword");
            entity.Property(e => e.ApiKey).HasMaxLength(250);
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(150)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BalForward).HasColumnType("money");
            entity.Property(e => e.Balance)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.ChequeNo).HasMaxLength(230);
            entity.Property(e => e.ClerkName).HasMaxLength(145);
            entity.Property(e => e.ClerkStaffNo).HasMaxLength(120);
            entity.Property(e => e.CollectorId)
                .HasMaxLength(250)
                .HasColumnName("CollectorID");
            entity.Property(e => e.CollectorName).HasMaxLength(100);
            entity.Property(e => e.CompanyCode).HasMaxLength(250);
            entity.Property(e => e.ContraAcc)
                .HasMaxLength(50)
                .HasDefaultValue("A001");
            entity.Property(e => e.DateIssued).HasColumnType("datetime");
            entity.Property(e => e.Dregard).HasColumnName("dregard");
            entity.Property(e => e.Firstdate)
                .HasColumnType("datetime")
                .HasColumnName("firstdate");
            entity.Property(e => e.IntAmount).HasColumnType("money");
            entity.Property(e => e.IntrOwed).HasColumnType("money");
            entity.Property(e => e.LoanAcc)
                .HasMaxLength(50)
                .HasDefaultValue("A007");
            entity.Property(e => e.LoanNo).HasMaxLength(30);
            entity.Property(e => e.MemberNo).HasMaxLength(50);
            entity.Property(e => e.Offsetamount)
                .HasColumnType("money")
                .HasColumnName("offsetamount");
            entity.Property(e => e.OrgAmt).HasColumnType("money");
            entity.Property(e => e.PaidBf).HasColumnType("money");
            entity.Property(e => e.Paymethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("paymethod");
            entity.Property(e => e.Premium)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.PremiumAcc)
                .HasMaxLength(50)
                .HasDefaultValue("E013");
            entity.Property(e => e.ProcessingFee).HasColumnType("money");
            entity.Property(e => e.Reasons).HasMaxLength(250);
            entity.Property(e => e.Refloan).HasColumnName("refloan");
            entity.Property(e => e.Remarks).HasMaxLength(120);
            entity.Property(e => e.SerialNo).HasMaxLength(250);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(130)
                .HasDefaultValue("BeforeTransactions");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.Voucheramount)
                .HasColumnType("money")
                .HasColumnName("voucheramount");
            entity.Property(e => e.Voucherno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("voucherno");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Acs).HasMaxLength(50);
            entity.Property(e => e.AuditTime).HasMaxLength(50);
            entity.Property(e => e.CompanyCode).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.ClientId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Idno)
                .HasMaxLength(50)
                .HasColumnName("IDNo");
            entity.Property(e => e.Othername).HasMaxLength(200);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.Pin)
                .HasMaxLength(200)
                .HasColumnName("PIN");
            entity.Property(e => e.PinStatus)
                .HasMaxLength(50)
                .HasColumnName("PIN_STATUS");
            entity.Property(e => e.SecretWord)
                .HasMaxLength(200)
                .HasColumnName("Secret_Word");
            entity.Property(e => e.Subscription).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(200);
            entity.Property(e => e.Unsubscribe).HasColumnName("unsubscribe");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("User_ID");
            entity.Property(e => e.UserId1)
                .HasMaxLength(150)
                .HasColumnName("UserID");
            entity.Property(e => e.UserRole).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(200);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_COMPANY_1");

            entity.ToTable("COMPANY");

            entity.Property(e => e.AccountNo).HasMaxLength(20);
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.AuditId)
                .HasMaxLength(10)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Capital).HasColumnType("money");
            entity.Property(e => e.Cigcode)
                .HasMaxLength(50)
                .HasColumnName("CIGCode");
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.CompanyName).HasMaxLength(500);
            entity.Property(e => e.Contactperson)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.County).HasMaxLength(50);
            entity.Property(e => e.CountyCode).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasDefaultValue(true)
                .HasColumnName("project");
            entity.Property(e => e.SubCounty).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(15);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Unitcode)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("unitcode");
            entity.Property(e => e.Village).HasMaxLength(50);
            entity.Property(e => e.Ward).HasMaxLength(50);
        });

        modelBuilder.Entity<Contrib>(entity =>
        {
            entity.ToTable("CONTRIB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.ApiKey).HasMaxLength(500);
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(200)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CashBookdate).HasColumnType("datetime");
            entity.Property(e => e.ChequeNo).HasMaxLength(500);
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.ContrDate).HasColumnType("datetime");
            entity.Property(e => e.ContraAcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DepositedDate).HasColumnType("datetime");
            entity.Property(e => e.Dregard).HasColumnName("dregard");
            entity.Property(e => e.Locked).HasMaxLength(3);
            entity.Property(e => e.MemberNo).HasMaxLength(200);
            entity.Property(e => e.MrCleared)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mrno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mrno");
            entity.Property(e => e.Offs).HasColumnName("offs");
            entity.Property(e => e.Offset).HasDefaultValue(false);
            entity.Property(e => e.Posted).HasMaxLength(3);
            entity.Property(e => e.ReceiptDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ReceiptNo).HasMaxLength(500);
            entity.Property(e => e.RefNo).HasMaxLength(250);
            entity.Property(e => e.Remarks).HasMaxLength(250);
            entity.Property(e => e.Run).HasDefaultValue(1L);
            entity.Property(e => e.Run2).HasDefaultValue(0);
            entity.Property(e => e.Schemecode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("schemecode");
            entity.Property(e => e.ShareBal).HasColumnType("money");
            entity.Property(e => e.SharesAcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sharescode).HasMaxLength(5);
            entity.Property(e => e.StaffNo).HasMaxLength(50);
            entity.Property(e => e.TransBy).HasMaxLength(50);
            entity.Property(e => e.TransDate).HasColumnType("datetime");
            entity.Property(e => e.TransNo)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.TransactionNo).HasMaxLength(255);
            entity.Property(e => e.TransferDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.SharescodeNavigation).WithMany(p => p.Contribs)
                .HasForeignKey(d => d.Sharescode)
                .HasConstraintName("FK_CONTRIB_sharetype");
        });

        modelBuilder.Entity<ContribShare>(entity =>
        {
            entity.ToTable("CONTRIB_SHARES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(200)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.ContrDate).HasColumnType("datetime");
            entity.Property(e => e.DepositedDate).HasColumnType("datetime");
            entity.Property(e => e.DepositsAmount).HasColumnType("money");
            entity.Property(e => e.Donor).HasColumnType("money");
            entity.Property(e => e.LoanAmount).HasColumnType("money");
            entity.Property(e => e.LoanNo).HasMaxLength(50);
            entity.Property(e => e.LocalId).HasColumnName("LOCAL_ID");
            entity.Property(e => e.MemberNo).HasMaxLength(20);
            entity.Property(e => e.PassBookAmount).HasColumnType("money");
            entity.Property(e => e.ReceiptDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RegFeeAmount).HasColumnType("money");
            entity.Property(e => e.ShareCapitalAmount).HasColumnType("money");
            entity.Property(e => e.Sharescode)
                .HasMaxLength(5)
                .HasColumnName("sharescode");
            entity.Property(e => e.TransactionNo).HasMaxLength(255);

            entity.HasOne(d => d.SharescodeNavigation).WithMany(p => p.ContribShares)
                .HasForeignKey(d => d.Sharescode)
                .HasConstraintName("FK_CONTRIB_SHARES_sharetype");
        });

        modelBuilder.Entity<CoopTransaction>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CheckoutRequestId)
                .HasMaxLength(200)
                .HasColumnName("CheckoutRequestID");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConversationId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ConversationID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MemberNo).HasMaxLength(200);
            entity.Property(e => e.MerchantRequestId)
                .HasMaxLength(200)
                .HasColumnName("MerchantRequestID");
            entity.Property(e => e.OriginatorConversationId)
                .HasMaxLength(200)
                .HasColumnName("OriginatorConversationID");
            entity.Property(e => e.Phone).HasMaxLength(250);
            entity.Property(e => e.ResultMessage).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCode).HasMaxLength(300);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(300)
                .HasColumnName("TransactionID");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Endmain>(entity =>
        {
            entity.HasKey(e => e.LoanNo);

            entity.ToTable("ENDMAIN");

            entity.Property(e => e.LoanNo).HasMaxLength(30);
            entity.Property(e => e.Accepted).HasMaxLength(3);
            entity.Property(e => e.AmtApproved).HasColumnType("money");
            entity.Property(e => e.AuditId)
                .HasMaxLength(50)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ChairSigned).HasMaxLength(3);
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.MeetingDate).HasColumnType("smalldatetime");
            entity.Property(e => e.MembSigned).HasMaxLength(3);
            entity.Property(e => e.MinuteNo).HasMaxLength(20);
            entity.Property(e => e.Reasons).HasMaxLength(200);
            entity.Property(e => e.Remarks).HasMaxLength(100);
            entity.Property(e => e.SecSigned).HasMaxLength(3);
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeneralLedger>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccBal).HasColumnType("money");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Chequeno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.Credits).HasColumnType("money");
            entity.Property(e => e.Debits).HasColumnType("money");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Glname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GLName");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("source");
            entity.Property(e => e.Transdate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Gltransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GLTRANSACTIONS");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(150)
                .HasDefaultValue("Admin")
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ChequeNo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.CrAccNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DocPosted).HasColumnName("doc_posted");
            entity.Property(e => e.DocumentNo)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.DrAccNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Dregard)
                .HasDefaultValue(false)
                .HasColumnName("dregard");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Module)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("BOSASaccos");
            entity.Property(e => e.Source)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.Temp)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.TransDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TransDescript).HasDefaultValue("");
            entity.Property(e => e.TransactionNo).HasMaxLength(130);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => new { e.CompanyCode, e.LoanNo });

            entity.ToTable("LOANS");

            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.LoanNo).HasMaxLength(50);
            entity.Property(e => e.Aamount)
                .HasColumnType("money")
                .HasColumnName("aamount");
            entity.Property(e => e.AddSecurity).HasMaxLength(30);
            entity.Property(e => e.ApiKey).HasMaxLength(250);
            entity.Property(e => e.ApplicDate).HasColumnType("datetime");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(150)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BasicSalary)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.Bridging)
                .HasDefaultValue(false)
                .HasColumnName("bridging");
            entity.Property(e => e.Cshares).HasColumnType("money");
            entity.Property(e => e.Gperiod)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Grosspay).HasColumnType("money");
            entity.Property(e => e.Guaranteed).HasMaxLength(10);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdNo).HasMaxLength(50);
            entity.Property(e => e.InsPercent).HasColumnType("money");
            entity.Property(e => e.Insurance).HasColumnType("money");
            entity.Property(e => e.Interest)
                .HasDefaultValue(12m)
                .HasColumnType("money");
            entity.Property(e => e.JobGrp).HasMaxLength(10);
            entity.Property(e => e.LoanAmt).HasColumnType("money");
            entity.Property(e => e.LoanCode).HasMaxLength(50);
            entity.Property(e => e.MaxLoanamt).HasColumnType("money");
            entity.Property(e => e.MemberNo).HasMaxLength(20);
            entity.Property(e => e.Phcf)
                .HasColumnType("money")
                .HasColumnName("PHCF");
            entity.Property(e => e.Posted).HasMaxLength(5);
            entity.Property(e => e.PremiumPayable).HasColumnType("money");
            entity.Property(e => e.PreparedBy).HasMaxLength(40);
            entity.Property(e => e.Purpose).HasMaxLength(50);
            entity.Property(e => e.Refinancing)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RepayMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Repayrate)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("repayrate");
            entity.Property(e => e.Rescheduledate)
                .HasColumnType("datetime")
                .HasColumnName("rescheduledate");
            entity.Property(e => e.Run).HasDefaultValue(0);
            entity.Property(e => e.Run2).HasDefaultValue(0);
            entity.Property(e => e.SerialNo).HasMaxLength(250);
            entity.Property(e => e.Sharecapital)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.Sourceofrepayment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue(4);
            entity.Property(e => e.SupMemberNo).HasMaxLength(20);
            entity.Property(e => e.SupSigned).HasMaxLength(3);
            entity.Property(e => e.TotalPremium).HasColumnType("money");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(30)
                .HasDefaultValue("BAL B/F");
            entity.Property(e => e.UserName).HasMaxLength(250);
            entity.Property(e => e.WitMemberNo).HasMaxLength(20);
            entity.Property(e => e.WitSigned).HasMaxLength(3);
        });

        modelBuilder.Entity<Loanbal>(entity =>
        {
            entity.HasKey(e => new { e.Companycode, e.LoanNo });

            entity.ToTable("LOANBAL");

            entity.Property(e => e.Companycode).HasMaxLength(100);
            entity.Property(e => e.LoanNo).HasMaxLength(50);
            entity.Property(e => e.ApiKey).HasMaxLength(250);
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(150)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AutoCalc).HasDefaultValue(true);
            entity.Property(e => e.Balance).HasColumnType("money");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cease)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Defaulter)
                .HasMaxLength(50)
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Duedate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("duedate");
            entity.Property(e => e.FirstDate).HasColumnType("datetime");
            entity.Property(e => e.Gperiod)
                .HasMaxLength(10)
                .HasDefaultValueSql("((1))")
                .IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Installments).HasColumnType("money");
            entity.Property(e => e.IntBalance).HasColumnType("money");
            entity.Property(e => e.Interest).HasColumnType("money");
            entity.Property(e => e.InterestAccrued).HasColumnType("money");
            entity.Property(e => e.IntrAmount).HasColumnType("money");
            entity.Property(e => e.IntrCharged)
                .HasColumnType("money")
                .HasColumnName("intrCharged");
            entity.Property(e => e.IntrOwed).HasColumnType("money");
            entity.Property(e => e.IntrOwed2).HasColumnType("money");
            entity.Property(e => e.LastDate).HasColumnType("datetime");
            entity.Property(e => e.LoanCode).HasMaxLength(50);
            entity.Property(e => e.MemberNo).HasMaxLength(50);
            entity.Property(e => e.Month).HasMaxLength(50);
            entity.Property(e => e.Nextduedate)
                .HasColumnType("datetime")
                .HasColumnName("nextduedate");
            entity.Property(e => e.Penalty).HasColumnType("money");
            entity.Property(e => e.Processdate).HasColumnType("datetime");
            entity.Property(e => e.Receiptno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(350);
            entity.Property(e => e.RepayMethod).HasMaxLength(50);
            entity.Property(e => e.RepayMode).HasDefaultValue((short)1);
            entity.Property(e => e.RepayRate).HasColumnType("money");
            entity.Property(e => e.RepayRate2).HasColumnType("money");
            entity.Property(e => e.Run).HasDefaultValue(0L);
            entity.Property(e => e.SerialNo).HasMaxLength(250);
            entity.Property(e => e.TransactionNo).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.Year).HasMaxLength(50);
        });

        modelBuilder.Entity<Loanguar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOANGUAR");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AuditId)
                .HasMaxLength(250)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime).HasColumnType("datetime");
            entity.Property(e => e.Balance).HasColumnType("money");
            entity.Property(e => e.Collateral)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("collateral");
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FullNames)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LoanNo).HasMaxLength(50);
            entity.Property(e => e.MemberNo).HasMaxLength(20);
            entity.Property(e => e.Tguaranto)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("tguaranto");
            entity.Property(e => e.Transdate).HasColumnType("datetime");
            entity.Property(e => e.Transfered).HasColumnName("transfered");
        });

        modelBuilder.Entity<Loantype>(entity =>
        {
            entity.ToTable("LOANTYPE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Accno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("accno");
            entity.Property(e => e.AccruedAcc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.ApiKey).HasMaxLength(250);
            entity.Property(e => e.ApprovalStatus).HasMaxLength(50);
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(50)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Bankloan)
                .HasColumnType("money")
                .HasColumnName("bankloan");
            entity.Property(e => e.CompanyCode).HasMaxLength(350);
            entity.Property(e => e.ContraAcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContraAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .HasColumnName("contraAccount");
            entity.Property(e => e.DefaultLoanno)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EarningRation).HasColumnType("money");
            entity.Property(e => e.Guarantor).HasMaxLength(50);
            entity.Property(e => e.IntAccno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Interest).HasMaxLength(50);
            entity.Property(e => e.InterestAcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Intrecovery)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("periodic")
                .HasColumnName("intrecovery");
            entity.Property(e => e.IsFimg)
                .HasDefaultValueSql("('0')")
                .HasColumnName("isFIMG");
            entity.Property(e => e.IsMain).HasColumnName("isMain");
            entity.Property(e => e.LoanAcc)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LoanCode).HasMaxLength(5);
            entity.Property(e => e.LoanOverpaymentAcc).HasMaxLength(50);
            entity.Property(e => e.LoanProduct).HasMaxLength(50);
            entity.Property(e => e.LoanType1)
                .HasMaxLength(350)
                .HasColumnName("LoanType");
            entity.Property(e => e.MaxAmount).HasColumnType("money");
            entity.Property(e => e.Mdtei)
                .HasDefaultValue((short)7)
                .HasColumnName("MDTEI");
            entity.Property(e => e.MinimumPaidForBridging).HasDefaultValue((short)50);
            entity.Property(e => e.MinimumPaidForTopup).HasDefaultValue((short)30);
            entity.Property(e => e.MobileCreatedBy).HasMaxLength(300);
            entity.Property(e => e.MobileCreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MobileLoan).HasDefaultValue(false);
            entity.Property(e => e.Nssf)
                .HasColumnType("money")
                .HasColumnName("NSSF");
            entity.Property(e => e.OtherDeduct).HasColumnType("money");
            entity.Property(e => e.OverpaymentAcc).HasMaxLength(50);
            entity.Property(e => e.PenaltyAcc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Periodrepaid).HasColumnName("periodrepaid");
            entity.Property(e => e.Ppacc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("L041")
                .HasColumnName("PPAcc");
            entity.Property(e => e.PremiumAcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PremiumContraAcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Processingfee).HasColumnType("money");
            entity.Property(e => e.ReceivableAcc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("((602012))");
            entity.Property(e => e.Repaymethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("RBAL");
            entity.Property(e => e.SchemeCode).HasMaxLength(5);
            entity.Property(e => e.SelfGuarantee)
                .HasDefaultValue(false)
                .HasColumnName("selfGuarantee");
            entity.Property(e => e.UseintRange).HasColumnName("useintRange");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.ValueChain).HasMaxLength(50);
            entity.Property(e => e.WaitingPeriod)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("MEMBERS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accepted).HasMaxLength(255);
            entity.Property(e => e.Accno)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("accno");
            entity.Property(e => e.AgentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApiKey).HasMaxLength(250);
            entity.Property(e => e.ApplicDate).HasColumnType("datetime");
            entity.Property(e => e.Archived).HasDefaultValue(false);
            entity.Property(e => e.AsAtDate).HasColumnType("datetime");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(255)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BankCode)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Bname).HasMaxLength(450);
            entity.Property(e => e.Cigcode)
                .HasMaxLength(50)
                .HasColumnName("CIGCode");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Dept).HasMaxLength(255);
            entity.Property(e => e.District).HasMaxLength(255);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EDate)
                .HasColumnType("datetime")
                .HasColumnName("E_DATE");
            entity.Property(e => e.EffectDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Employer).HasMaxLength(255);
            entity.Property(e => e.Entrance)
                .HasMaxLength(50)
                .HasDefaultValue("False");
            entity.Property(e => e.FormFilled)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HomeAddr)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HomeTelNo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Idno)
                .HasMaxLength(50)
                .HasColumnName("IDNo");
            entity.Property(e => e.InitShares)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.InitsharesTransfered)
                .HasColumnType("money")
                .HasColumnName("initsharesTransfered");
            entity.Property(e => e.InterestBalance).HasColumnType("money");
            entity.Property(e => e.LoanBalance).HasColumnType("money");
            entity.Property(e => e.MemberDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("ORDINARY");
            entity.Property(e => e.MemberNo).HasMaxLength(20);
            entity.Property(e => e.MembershipType).HasMaxLength(50);
            entity.Property(e => e.Memberwitrawaldate)
                .HasColumnType("datetime")
                .HasColumnName("memberwitrawaldate");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MonthlyContr).HasDefaultValue(0.0);
            entity.Property(e => e.Mstatus)
                .HasDefaultValue(true)
                .HasColumnName("mstatus");
            entity.Property(e => e.OfficeTelNo).HasMaxLength(255);
            entity.Property(e => e.OtherNames).HasMaxLength(555);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Pin)
                .HasMaxLength(53)
                .IsUnicode(false)
                .HasColumnName("PIN");
            entity.Property(e => e.Posted)
                .HasMaxLength(255)
                .HasColumnName("posted");
            entity.Property(e => e.PresentAddr).HasMaxLength(255);
            entity.Property(e => e.ProfileString).IsUnicode(false);
            entity.Property(e => e.Province).HasMaxLength(255);
            entity.Property(e => e.Rank).HasMaxLength(255);
            entity.Property(e => e.RegFee)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.Run).HasDefaultValue(0);
            entity.Property(e => e.Sex).HasMaxLength(255);
            entity.Property(e => e.ShareCap).HasColumnType("money");
            entity.Property(e => e.Signed).HasMaxLength(255);
            entity.Property(e => e.StaffNo).HasMaxLength(20);
            entity.Property(e => e.Station).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasDefaultValue((short)1)
                .HasColumnName("status");
            entity.Property(e => e.Surname).HasMaxLength(555);
            entity.Property(e => e.Terms).HasMaxLength(255);
            entity.Property(e => e.TransactionNo).HasMaxLength(300);
            entity.Property(e => e.Transferdate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.Withdrawn).HasDefaultValue(false);
        });

        modelBuilder.Entity<Repay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REPAY");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.ApiKey).HasMaxLength(250);
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(150)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BrgLoan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BridgeInterest).HasColumnType("money");
            entity.Property(e => e.CashBookDate).HasColumnType("datetime");
            entity.Property(e => e.Ch)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Chequeno)
                .HasMaxLength(150)
                .HasColumnName("chequeno");
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.ContraAcc).HasMaxLength(50);
            entity.Property(e => e.DateReceived).HasColumnType("datetime");
            entity.Property(e => e.Dregard).HasColumnName("dregard");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IntBalance).HasColumnType("money");
            entity.Property(e => e.Interest).HasColumnType("money");
            entity.Property(e => e.InterestAcc).HasMaxLength(50);
            entity.Property(e => e.Interestaccrued)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.IntrAccrued)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.IntrCharged)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.IntrOwed)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.LoanAcc).HasMaxLength(150);
            entity.Property(e => e.LoanBalance)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.LoanNo).HasMaxLength(50);
            entity.Property(e => e.Loancode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberNo).HasMaxLength(50);
            entity.Property(e => e.Mrcleared)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MRCleared");
            entity.Property(e => e.Mrno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MRNo");
            entity.Property(e => e.Nextduedate)
                .HasColumnType("datetime")
                .HasColumnName("nextduedate");
            entity.Property(e => e.Offs).HasColumnName("offs");
            entity.Property(e => e.Penalty)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.Principal).HasColumnType("money");
            entity.Property(e => e.ReceiptNo).HasMaxLength(150);
            entity.Property(e => e.Remarks).HasMaxLength(250);
            entity.Property(e => e.RepayRate).HasColumnType("money");
            entity.Property(e => e.Run).HasDefaultValue(0L);
            entity.Property(e => e.SerialNo).HasMaxLength(250);
            entity.Property(e => e.Statementdate).HasColumnType("datetime");
            entity.Property(e => e.TransDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionNo).HasMaxLength(100);
            entity.Property(e => e.Transby)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Transno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(150);
        });

        modelBuilder.Entity<Share>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SHARES");

            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(10)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.Initshares).HasColumnType("money");
            entity.Property(e => e.LastDivDate).HasColumnType("datetime");
            entity.Property(e => e.Loanbal)
                .HasColumnType("money")
                .HasColumnName("loanbal");
            entity.Property(e => e.MemberNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sharescode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sharescode");
            entity.Property(e => e.Statementshares).HasColumnType("money");
            entity.Property(e => e.TotalShares).HasColumnType("money");
            entity.Property(e => e.TransDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Sharetype>(entity =>
        {
            entity.HasKey(e => e.SharesCode);

            entity.ToTable("sharetype");

            entity.Property(e => e.SharesCode).HasMaxLength(5);
            entity.Property(e => e.Accno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("accno");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId)
                .HasMaxLength(50)
                .HasColumnName("AuditID");
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.ContraAcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ElseRatio).HasColumnType("money");
            entity.Property(e => e.Guarantor).HasMaxLength(50);
            entity.Property(e => e.Interest).HasColumnType("money");
            entity.Property(e => e.Loanquaranto).HasColumnName("loanquaranto");
            entity.Property(e => e.LowerLimit).HasColumnType("money");
            entity.Property(e => e.MaxAmount).HasColumnType("money");
            entity.Property(e => e.MinAmount).HasColumnType("money");
            entity.Property(e => e.Ppacc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("L041")
                .HasColumnName("PPAcc");
            entity.Property(e => e.Shareboost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("shareboost");
            entity.Property(e => e.SharesAcc)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SharesType).HasMaxLength(50);
            entity.Property(e => e.UsedToOffset).HasDefaultValue(true);
            entity.Property(e => e.Withdrawable).HasDefaultValue(true);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId).HasMaxLength(300);
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Channel)
                .HasMaxLength(80)
                .IsFixedLength();
            entity.Property(e => e.CompanyCode).HasMaxLength(250);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Active")
                .HasColumnName("status");
            entity.Property(e => e.TransDate).HasColumnType("datetime");
            entity.Property(e => e.TransDescription)
                .HasMaxLength(250)
                .HasColumnName("transDescription");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(30)
                .HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC2714D2C3C1");

            entity.ToTable("Transaction_detail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CheckoutRequestId)
                .HasMaxLength(200)
                .HasColumnName("CheckoutRequestID");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConversationId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ConversationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("deleted_at");
            entity.Property(e => e.MemberNo).HasMaxLength(200);
            entity.Property(e => e.MerchantRequestId)
                .HasMaxLength(200)
                .HasColumnName("MerchantRequestID");
            entity.Property(e => e.OriginatorConversationId)
                .HasMaxLength(200)
                .HasColumnName("OriginatorConversationID");
            entity.Property(e => e.Phone).HasMaxLength(250);
            entity.Property(e => e.ResultMessage).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCode).HasMaxLength(300);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(300)
                .HasColumnName("TransactionID");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Transactions2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Transactions2");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AuditDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditId).HasMaxLength(300);
            entity.Property(e => e.AuditTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Companycode).HasMaxLength(250);
            entity.Property(e => e.Contact).HasMaxLength(300);
            entity.Property(e => e.ContributionDate).HasColumnType("datetime");
            entity.Property(e => e.DepositedDate).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MemberNo).HasMaxLength(150);
            entity.Property(e => e.PaymentMode).HasMaxLength(150);
            entity.Property(e => e.ReceiptNo).HasMaxLength(150);
            entity.Property(e => e.RunE).HasDefaultValue(0);
            entity.Property(e => e.SessionId).HasMaxLength(250);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Active")
                .HasColumnName("status");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(30)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TransactionType).HasMaxLength(150);
        });

        modelBuilder.Entity<UserAccounts1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserAccounts1");

            entity.Property(e => e.ApprovalStatus).HasMaxLength(50);
            entity.Property(e => e.AssignGl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Branchcode)
                .HasMaxLength(50)
                .HasColumnName("branchcode");
            entity.Property(e => e.Cigcode)
                .HasMaxLength(50)
                .HasColumnName("CIGcode");
            entity.Property(e => e.CompanyCode).HasMaxLength(50);
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DepCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Euser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("euser");
            entity.Property(e => e.Expirydate)
                .HasMaxLength(50)
                .HasColumnName("expirydate");
            entity.Property(e => e.FailedAttempts).HasDefaultValue(0);
            entity.Property(e => e.IsLocked).HasDefaultValue(false);
            entity.Property(e => e.Levels)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("levels");
            entity.Property(e => e.MemberNo).HasMaxLength(50);
            entity.Property(e => e.PassExpire)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PasswordStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passwordStatus");
            entity.Property(e => e.Phone)
                .HasMaxLength(250)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.Sign)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sign");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SubCounty).HasMaxLength(50);
            entity.Property(e => e.Superuser).HasColumnName("SUPERUSER");
            entity.Property(e => e.UserGroup).HasMaxLength(50);
            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.UserLoginId)
                .HasMaxLength(250)
                .HasColumnName("UserLoginID");
            entity.Property(e => e.UserName).HasMaxLength(250);
            entity.Property(e => e.Userstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userstatus");
            entity.Property(e => e.VendorId).HasColumnName("vendor_ID");
            entity.Property(e => e.Ward).HasMaxLength(50);
        });

        modelBuilder.Entity<WicciClient>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Wicci_Clients");

            entity.Property(e => e.Acs).HasMaxLength(50);
            entity.Property(e => e.AuditTime).HasMaxLength(50);
            entity.Property(e => e.CompanyCode).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Idno)
                .HasMaxLength(50)
                .HasColumnName("IDNo");
            entity.Property(e => e.Othername).HasMaxLength(200);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.Pin)
                .HasMaxLength(200)
                .HasColumnName("PIN");
            entity.Property(e => e.PinStatus)
                .HasMaxLength(50)
                .HasColumnName("PIN_STATUS");
            entity.Property(e => e.SecretWord)
                .HasMaxLength(200)
                .HasColumnName("Secret_Word");
            entity.Property(e => e.Subscription).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(200);
            entity.Property(e => e.Unsubscribe).HasColumnName("unsubscribe");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("User_ID");
            entity.Property(e => e.UserId1)
                .HasMaxLength(150)
                .HasColumnName("UserID");
            entity.Property(e => e.UserRole).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
