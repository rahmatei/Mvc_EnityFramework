using Microsoft.EntityFrameworkCore;
using MVCEntityFrameWork.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCEntityFrameWork.Models;

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
            modelBuilder.ApplyConfiguration(new Book_CategoryMap());


            modelBuilder.Entity<Author>().HasKey(k => k.AuthorID);
            modelBuilder.Entity<Discount>().HasKey(k => k.BookID);
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasColumnName("fname");
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasColumnType("nvarchar(20)");
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasColumnName("Lname");
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Ignore(p => p.Age);

            modelBuilder.Entity<Provice>().HasKey(p => p.ProvinceID);


            



        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Provice> Provices { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
        public DbSet<Order_Book> Order_Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Translator> Translator { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book_Category> Book_Categories { get; set; }
        public DbSet<Book_Translator> Book_Translators { get; set; }
    }
}
