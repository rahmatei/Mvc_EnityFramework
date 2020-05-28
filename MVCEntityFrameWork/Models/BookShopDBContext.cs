using Microsoft.EntityFrameworkCore;
using MVCEntityFrameWork.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Models
{
    public class BookShopDBContext:DbContext
    {
        public BookShopDBContext(DbContextOptions option)
            :base(option)
        {

        }

        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=BookShopDB;Trusted_Connection=True");

        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Author_BookMap());
            modelBuilder.ApplyConfiguration(new Book_Map());
            modelBuilder.ApplyConfiguration(new Book_TranslatorMap());


            modelBuilder.Entity<Author>().HasKey(k => k.AuthorID);
            modelBuilder.Entity<Discount>().HasKey(k => k.BookID);
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasColumnName("fname");
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasColumnType("nvarchar(20)");
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasColumnName("Lname");
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Ignore(p => p.Age);

            modelBuilder.Entity<Provice>().HasKey(p => p.ProvinceID);


            



        }
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Provice> Provices { get; set; }
        DbSet<Author_Book> Author_Books { get; set; }
        DbSet<Order_Book> Order_Books { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<Customer> Customers { get; set; }
    }
}
