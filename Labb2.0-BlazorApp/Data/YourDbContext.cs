using System;
using System.Collections.Generic;
using Labb2._0_BlazorApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Labb2._0_BlazorApp.Data;

public partial class YourDbContext : DbContext
{
    public YourDbContext()
    {
    }

    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public bool flyttabok(string Isbn, int FromeStoreID, int ToStoreID, int Quantity)
    {
        List<SqlParameter>sqlParam = new List<SqlParameter>();
        sqlParam.Add(new SqlParameter("@ISBN13", Isbn));
		sqlParam.Add(new SqlParameter("@NyStoreID", ToStoreID));
		sqlParam.Add(new SqlParameter("@FromStoreID", FromeStoreID));
		sqlParam.Add(new SqlParameter("@Coppies", Quantity));
		int result = Database.ExecuteSqlRaw("dbo.FlyttaBok @ISBN13 ,@NyStoreID ,@FromStoreID ,@Coppies", sqlParam.ToArray());
        return result > 0;  
    }


    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStockInStore> BookStockInStore { get; set; }

    //public virtual DbSet<BookStockInStore1> BookStockInStores1 { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Felixzoon;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__70DAFC142BA7F681");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn13).HasName("PK__Books__3BF79E038D206177");

            entity.Property(e => e.Isbn13)
                .HasMaxLength(20)
                .HasColumnName("ISBN13");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Languege).HasMaxLength(255);
            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");
            entity.Property(e => e.ReleaseDate).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Books__AuthorID__36B12243");
        });

        modelBuilder.Entity<BookStockInStore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BookStockInStore");

            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.Isbn13)
                .HasMaxLength(20)
                .HasColumnName("ISBN13");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        //modelBuilder.Entity<BookStockInStore1>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("BookStockInStores");

        //    entity.Property(e => e.Category).HasMaxLength(255);
        //    entity.Property(e => e.FirstName).HasMaxLength(255);
        //    entity.Property(e => e.Isbn13)
        //        .HasMaxLength(20)
        //        .HasColumnName("ISBN13");
        //    entity.Property(e => e.LastName).HasMaxLength(255);
        //    entity.Property(e => e.StoreId).HasColumnName("StoreID");
        //    entity.Property(e => e.Title).HasMaxLength(255);
        //});

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B82C3B084D");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1573B60D0");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeEmail).HasMaxLength(255);
            entity.Property(e => e.EmployeeLastName).HasMaxLength(255);
            entity.Property(e => e.EmployeeName).HasMaxLength(255);

            entity.HasOne(d => d.EmployeeStoreNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeStore)
                .HasConstraintName("FK__Employee__Employ__45F365D3");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => new { e.InventoryId, e.Isbn }).HasName("PK__Inventor__51BA35BD57CD28AC");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.InventoryNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Inven__3B75D760");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__ISBN__3C69FB99");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF39C14F24");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__412EB0B6");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PK__Publishe__4C657E4B7223CCDB");

            entity.ToTable("Publisher");

            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");
            entity.Property(e => e.PublisherName).HasMaxLength(255);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__3B82F0E11C07379A");

            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.StoreNamn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Storedress)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
