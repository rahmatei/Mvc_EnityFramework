﻿// <auto-generated />
using System;
using MVCEntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCEntityFrameWork.Migrations
{
    [DbContext(typeof(BookShopDBContext))]
    partial class BookShopDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCEntityFrameWork.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Author_Book", b =>
                {
                    b.Property<int>("AuthorID");

                    b.Property<int>("BookID");

                    b.HasKey("AuthorID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("Author_Books");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("File");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image");

                    b.Property<int>("LanguageID");

                    b.Property<int>("Price");

                    b.Property<int>("SCategoryID");

                    b.Property<int>("Stock");

                    b.Property<string>("Summary");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("BookID");

                    b.HasIndex("LanguageID");

                    b.HasIndex("SCategoryID");

                    b.ToTable("BookInfo");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.City", b =>
                {
                    b.Property<int>("CityID");

                    b.Property<string>("CityName");

                    b.Property<int?>("ProviceProvinceID");

                    b.HasKey("CityID");

                    b.HasIndex("ProviceProvinceID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Customer", b =>
                {
                    b.Property<string>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int?>("City1CityID");

                    b.Property<int?>("City2CityID");

                    b.Property<string>("FirstName")
                        .HasColumnName("fname")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Image");

                    b.Property<string>("LastName")
                        .HasColumnName("Lname")
                        .HasMaxLength(100);

                    b.Property<string>("Mobile");

                    b.Property<string>("Tell");

                    b.HasKey("CustomerID");

                    b.HasIndex("City1CityID");

                    b.HasIndex("City2CityID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Discount", b =>
                {
                    b.Property<int>("BookID");

                    b.Property<DateTime?>("EndDate");

                    b.Property<byte>("Percent");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("BookID");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Language", b =>
                {
                    b.Property<int>("LanguageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName");

                    b.HasKey("LanguageID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Order", b =>
                {
                    b.Property<string>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AmountPaid");

                    b.Property<DateTime>("BuyDate");

                    b.Property<string>("CustomerID");

                    b.Property<string>("DispatchNumber");

                    b.Property<int?>("OrderStatusID");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("OrderStatusID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Order_Book", b =>
                {
                    b.Property<int>("Order_BookID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID");

                    b.Property<string>("OrderID");

                    b.HasKey("Order_BookID");

                    b.HasIndex("BookID");

                    b.HasIndex("OrderID");

                    b.ToTable("Order_Books");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderStatusName");

                    b.HasKey("OrderStatusID");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Provice", b =>
                {
                    b.Property<int>("ProvinceID");

                    b.Property<string>("ProvinceName");

                    b.HasKey("ProvinceID");

                    b.ToTable("Provices");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID");

                    b.Property<string>("SubCategoryName");

                    b.HasKey("SubCategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Author_Book", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.Author", "Author")
                        .WithMany("Author_Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MVCEntityFrameWork.Models.Book", "Book")
                        .WithMany("Author_Books")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Book", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MVCEntityFrameWork.Models.SubCategory", "SubCategory")
                        .WithMany("Books")
                        .HasForeignKey("SCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.City", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.Provice", "Provice")
                        .WithMany("Cities")
                        .HasForeignKey("ProviceProvinceID");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Customer", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.City", "City1")
                        .WithMany("Customers1")
                        .HasForeignKey("City1CityID");

                    b.HasOne("MVCEntityFrameWork.Models.City", "City2")
                        .WithMany("Customers2")
                        .HasForeignKey("City2CityID");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Discount", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.Book", "Book")
                        .WithOne("Discount")
                        .HasForeignKey("MVCEntityFrameWork.Models.Discount", "BookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Order", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID");

                    b.HasOne("MVCEntityFrameWork.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusID");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.Order_Book", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.Book", "Book")
                        .WithMany("Order_Books")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MVCEntityFrameWork.Models.Order", "Order")
                        .WithMany("Order_Books")
                        .HasForeignKey("OrderID");
                });

            modelBuilder.Entity("MVCEntityFrameWork.Models.SubCategory", b =>
                {
                    b.HasOne("MVCEntityFrameWork.Models.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}
