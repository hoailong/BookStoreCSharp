using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStore.Models
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        //public const String SQL_CONNECTION_STRING = "Server=SERVER_NAME\\;Database=BookStore;Trusted_Connection=True;";
        public const String SQL_CONNECTION_STRING = @"Data Source=LAPTOP-C4E4J3V9;Initial Catalog=BookStore;Integrated Security=True";

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Pay> Pay { get; set; }
        public virtual DbSet<PayDetail> PayDetail { get; set; }
        public virtual DbSet<Penalty> Penalty { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<RentDetail> RentDetail { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(SQL_CONNECTION_STRING);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'12345')");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Account_Employee");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.AuthorName).HasMaxLength(100);

                entity.Property(e => e.Birth)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookName).HasMaxLength(100);

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Book_Category");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.LangId)
                    .HasConstraintName("FK_Book_Language");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_Book_Publisher");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Book_Type");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Book_Author");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryCode).HasMaxLength(100);

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Birth)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'Khách hàng')");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Birth)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'Nhân viên')");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_Employee_Shift");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LangId)
                    .HasName("PK_Language");

                entity.ToTable("language");

                entity.Property(e => e.LangName).HasMaxLength(100);
            });

            modelBuilder.Entity<Pay>(entity =>
            {
                entity.ToTable("pay");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Pay)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Pay_Employee");
            });

            modelBuilder.Entity<PayDetail>(entity =>
            {
                entity.HasKey(e => new { e.RentId, e.BookId, e.PayId})
                    .HasName("PK_PayDetail");

                entity.ToTable("payDetail");

                entity.Property(e => e.PayId).ValueGeneratedNever();

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.PayDetail)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayDetail_Book");

                entity.HasOne(d => d.Pay)
                    .WithOne(p => p.PayDetail)
                    .HasForeignKey<PayDetail>(d => d.PayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayDetail_Pay");

                entity.HasOne(d => d.Penalty)
                    .WithMany(p => p.PayDetail)
                    .HasForeignKey(d => d.PenaltyId)
                    .HasConstraintName("FK_PayDetail_Penalty");
            });

            modelBuilder.Entity<Penalty>(entity =>
            {
                entity.ToTable("penalty");

                entity.Property(e => e.PenaltyName).HasMaxLength(100);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PublisherName).HasMaxLength(100);
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.ToTable("rent");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rent)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Rent_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Rent)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Rent_Employee");
            });

            modelBuilder.Entity<RentDetail>(entity =>
            {
                entity.HasKey(e => new { e.RentId, e.BookId })
                    .HasName("PK_RentDetail");

                entity.ToTable("rentDetail");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.RentDetail)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentDetail_Book");

                entity.HasOne(d => d.Rent)
                    .WithMany(p => p.RentDetail)
                    .HasForeignKey(d => d.RentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentDetail_Rent");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.RentDetail)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentDetail_State");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleName).HasMaxLength(20);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("shift");

                entity.Property(e => e.ShiftName).HasMaxLength(100);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.StateName).HasMaxLength(100);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type");

                entity.Property(e => e.TypeName).HasMaxLength(100);
            });
        }
    }
}
