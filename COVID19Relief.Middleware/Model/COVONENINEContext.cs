using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace COVID19Relief.Middleware.Model
{
    public partial class COVONENINEContext : DbContext
    {
        public COVONENINEContext()
        {
        }

        public COVONENINEContext(DbContextOptions<COVONENINEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<Bvndetails> Bvndetails { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<SalaryDetails> SalaryDetails { get; set; }
        public virtual DbSet<SalaryWorkersDetails> SalaryWorkersDetails { get; set; }
        public virtual DbSet<SelfEmployedWorkersDetails> SelfEmployedWorkersDetails { get; set; }
        public virtual DbSet<StatesTable> StatesTable { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=40.122.172.154;Database=COVONENINE;user id=ReliefRegAdmin;password=M$SQLMu11@123$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banks>(entity =>
            {
                entity.HasKey(e => e.BankId);

                entity.Property(e => e.BankCode).HasMaxLength(50);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankSortCode).HasMaxLength(50);

                entity.Property(e => e.BankType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nipcode)
                    .HasColumnName("NIPCode")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Bvndetails>(entity =>
            {
                entity.ToTable("BVNDetails");

                entity.Property(e => e.BvndetailsId).HasColumnName("BVNDetailsId");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnrollmentBank)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LgaofOrigin)
                    .IsRequired()
                    .HasColumnName("LGAOfOrigin")
                    .HasMaxLength(50);

                entity.Property(e => e.LgaofResidence)
                    .IsRequired()
                    .HasColumnName("LGAOfResidence")
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumberAlt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.ResidentialAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StateOfOrigin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StateOfResidence)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WatchListed)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bvndetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_BVNDetails");
            });

            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                entity.Property(e => e.PaymentDetailsId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CReatedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentRef)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Payment");
            });

            modelBuilder.Entity<SalaryDetails>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SalaryDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_SalaryDetails");
            });

            modelBuilder.Entity<SalaryWorkersDetails>(entity =>
            {
                entity.HasKey(e => e.SalaryWorkersDetaildId)
                    .HasName("PK__SalaryWo__1DBEF810780D63D0");

                entity.Property(e => e.ActiveEmail)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ActivePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AvgMonthlySalaryForSixMonths)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfEmployment).HasColumnType("datetime");

                entity.Property(e => e.DateOfLeaving).HasColumnType("datetime");

                entity.Property(e => e.EmployerIndustry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EmployerRcNoOrBrNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SalaryWorkersDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_SalaryWorkersDetails");
            });

            modelBuilder.Entity<SelfEmployedWorkersDetails>(entity =>
            {
                entity.Property(e => e.ActivePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ActiveResidentialAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.AvgMonthlySalaryForSixMonths)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessDescription).IsRequired();

                entity.Property(e => e.BusinessRcNoOrBrNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CloseDateOfBusiness).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfLeaving).HasColumnType("datetime");

                entity.Property(e => e.Industry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameOfBusiness)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.StartDateOfBusiness).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SelfEmployedWorkersDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_SelfEmployedWorkersDetails");
            });

            modelBuilder.Entity<StatesTable>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankId).HasMaxLength(50);

                entity.Property(e => e.Bvn)
                    .IsRequired()
                    .HasColumnName("bvn")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdentityDocumentType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StateId).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
