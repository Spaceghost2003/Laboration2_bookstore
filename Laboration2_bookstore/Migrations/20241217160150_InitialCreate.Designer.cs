﻿// <auto-generated />
using System;
using Laboration2_bookstore.BookstoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Laboration2_bookstore.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20241217160150_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Laboration2_bookstore.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Authors__3214EC275F1CBE1E");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Book", b =>
                {
                    b.Property<string>("Isbn13")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("ISBN13");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("AuthorID");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Isbn13")
                        .HasName("PK__Books__3BF79E03BD375F19");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CustomerID")
                        .HasDefaultValueSql("(right('00000000'+CONVERT([varchar],abs(checksum(newid()))%(100000000)),(8)))")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B865D58F37");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("ManagerID");

                    b.Property<int?>("WorkplaceId")
                        .HasColumnType("int")
                        .HasColumnName("WorkplaceID");

                    b.HasKey("Id")
                        .HasName("PK__Employee__3214EC27945558DE");

                    b.HasIndex("ManagerId");

                    b.HasIndex("WorkplaceId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.EmployeeInformation", b =>
                {
                    b.Property<string>("EmployeeFirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EmployeeLastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ManagerFirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ManagerLastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StoreName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToTable((string)null);

                    b.ToView("EmployeeInformation", (string)null);
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Inventory", b =>
                {
                    b.Property<int?>("Ammount")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("ISBN");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    b.HasIndex("Isbn");

                    b.HasIndex("StoreId");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Managers__3214EC2771D8B4D8");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Order", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CustomerID")
                        .IsFixedLength();

                    b.Property<string>("Item")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Item");

                    b.HasIndex("StoreId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Stores__3214EC27535B089B");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.StoreInventory", b =>
                {
                    b.Property<string>("BookIsbn")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("BookISBN");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StoreAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    b.Property<string>("StoreName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToTable((string)null);

                    b.ToView("StoreInventory", (string)null);
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.TitlesPerAuthor", b =>
                {
                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TitleCount")
                        .HasColumnType("int");

                    b.Property<double>("TotalBookValue")
                        .HasColumnType("float");

                    b.ToTable((string)null);

                    b.ToView("TitlesPerAuthor", (string)null);
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Book", b =>
                {
                    b.HasOne("Laboration2_bookstore.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK__Books__AuthourID__5070F446");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Employee", b =>
                {
                    b.HasOne("Laboration2_bookstore.Model.Manager", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__Employees__Manag__75A278F5");

                    b.HasOne("Laboration2_bookstore.Model.Store", "Workplace")
                        .WithMany("Employees")
                        .HasForeignKey("WorkplaceId")
                        .HasConstraintName("FK__Employees__Workp__74AE54BC");

                    b.Navigation("Manager");

                    b.Navigation("Workplace");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Inventory", b =>
                {
                    b.HasOne("Laboration2_bookstore.Model.Book", "IsbnNavigation")
                        .WithMany()
                        .HasForeignKey("Isbn")
                        .IsRequired()
                        .HasConstraintName("FK__Inventory__ISBN__59063A47");

                    b.HasOne("Laboration2_bookstore.Model.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .IsRequired()
                        .HasConstraintName("FK__Inventory__Store__59FA5E80");

                    b.Navigation("IsbnNavigation");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Order", b =>
                {
                    b.HasOne("Laboration2_bookstore.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Orders__Customer__619B8048");

                    b.HasOne("Laboration2_bookstore.Model.Book", "ItemNavigation")
                        .WithMany()
                        .HasForeignKey("Item")
                        .HasConstraintName("FK__Orders__Item__60A75C0F");

                    b.HasOne("Laboration2_bookstore.Model.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__Orders__StoreID__628FA481");

                    b.Navigation("Customer");

                    b.Navigation("ItemNavigation");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Laboration2_bookstore.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Manager", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Laboration2_bookstore.Model.Store", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
