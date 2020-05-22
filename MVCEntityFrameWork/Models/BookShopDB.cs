﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Models
{
    [Table("BookInfo")]
    public class Book
    {
        public int BookID { get; set; }

        public string Title { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string File { get; set; }

        public byte[] Image { get; set; }
        public int LanguageID { get; set; }


        public int SCategoryID { get; set; }

        public SubCategory SubCategory { get; set; }
        public Language Language { get; set; }

        public Discount Discount { get; set; }
        public List<Author_Book> Author_Books { get; set; }
        public List<Order_Book> Order_Books { get; set; }
    }

    public class Author_Book
    {

        public int BookID { get; set; }
        public int AuthorID { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }

    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Author_Book> Author_Books { get; set; }
    }

    public class Discount
    {
        public int BookID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte Percent { get; set; }

        public Book Book { get; set; }
    }

    public class Language
    {
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }

        public List<Book> Books { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<SubCategory> SubCategory { get; set; }
    }


    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }

        public Category Category { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Order
    {
        public string OrderID { get; set; }
        public long AmountPaid { get; set; }
        public string DispatchNumber { get; set; }
        public DateTime BuyDate { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public Customer Customer { get; set; }
        public List<Order_Book> Order_Books { get; set; }
    }

    public class Order_Book
    {
        [Key]
        public int Order_BookID { get; set; }
        public string OrderID { get; set; }
        public int BookID { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }


    public class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public string OrderStatusName { get; set; }

        public List<Order> Orders { get; set; }
    }

    public class Customer
    {
        public string CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Mobile { get; set; }
        public string Tell { get; set; }
        public string Image { get; set; }

        public int Age { get; set; }

        public City City1 { get; set; }
        public City City2 { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Provice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }

        public List<City> Cities { get; set; }
    }

    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }

        public Provice Provice { get; set; }

        [InverseProperty("City1")]
        public List<Customer> Customers1 { get; set; }

        [InverseProperty("City2")]
        public List<Customer> Customers2 { get; set; }
    }
}
