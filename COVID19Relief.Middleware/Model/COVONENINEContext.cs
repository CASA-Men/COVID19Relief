using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace COVID19Relief.Middleware.Model
{
    public partial class COVONENINEContext : DbContext
    {
        private readonly IConfiguration configuration;

        public COVONENINEContext()
        {
        }

        public COVONENINEContext(DbContextOptions<COVONENINEContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<EmploymentDetails> EmploymentDetails { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = configuration.GetConnectionString("CovOneNineMsSQLDb");
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(config);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmploymentDetails>(entity =>
            {
                entity.Property(e => e.EmploymentDetailsId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmploymentDate).HasColumnType("datetime");

                entity.Property(e => e.EmploymentStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmploymentType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastDayAtJob).HasColumnType("datetime");

                entity.Property(e => e.OrganizationAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OrganizationType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PositionHeld)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.EmploymentDetails)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_EmploymentDetails");
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

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FirstName)
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
