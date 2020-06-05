using Microsoft.EntityFrameworkCore;
using MVCEntityFrameWork.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Models.Repository
{
    public class BookRepository
    {
        private readonly BookShopDBContext _context;

        public BookRepository(BookShopDBContext context)
        {
            _context = context;
        }

        public List<TreeViewCategory> GenerateAllTree()
        {
            var Categories = (from c in _context.Categories
                              where (c.ParentCategoryID == null)
                              select new TreeViewCategory { id = c.CategoryID, title = c.CategoryName }).ToList();

            foreach (var item in Categories)
            {
                BindSubCategory(item);
            }
            return Categories;
        }

        public void BindSubCategory(TreeViewCategory category)
        {
            var subcategory = (from c in _context.Categories
                               where (c.ParentCategoryID == category.id)
                               select new TreeViewCategory { id = c.CategoryID, title = c.CategoryName });
            foreach (var item in subcategory)
            {
                BindSubCategory(item);
                category.subs.Add(item);
            }
        }

        public List<BooksIndexViewModel> GetBooks(string title, string ISBN, string Language, string Publisher, string Author, string Translator, string Category)
        {
            string AuthorName = "";
            string TranslatorName = "";
            string CategoryName = "";
            List<BooksIndexViewModel> BooksViewModel = new List<BooksIndexViewModel>();
            //var Books = (from b in _context.Books 
            //            join p in _context.Publishers on b.PublisherID equals p.PublisherID
            //            join u in _context.Author_Books on b.BookID equals u.BookID
            //            join a in _context.Authors on u.AuthorID equals a.AuthorID
            //            where b.Delete == false
            //            select new BooksIndexViewModel
            //            {
            //                BookId = b.BookID,
            //                ISBN = b.ISBN,
            //                IsPublish = b.IsPublish,
            //                Price = b.Price,
            //                PublishDate = b.PublishDate,
            //                Stock = b.Stock,
            //                Title = b.Title,
            //                PublisherName=p.PublisherName,
            //                Author= a.FirstName + " " + a.LastName,
            //            }).GroupBy(b=>b.BookId).Select(g=> new { BookID=g.Key, BookGroups=g }).ToList();

            var Books = (from u in _context.Author_Books
                        .Include(a => a.Author)
                        .Include(b => b.Book)
                        .ThenInclude(p=>p.publisher)
                        join l in _context.Languages on u.Book.LanguageID equals l.LanguageID
                        join tt in _context.Book_Translators on u.BookID equals tt.BookID into ttc
                        from bttc in ttc.DefaultIfEmpty()
                        join t in _context.Translator on bttc.TranslatorID equals t.TranslatorID into tc
                        from btc in tc.DefaultIfEmpty()
                        join cc in _context.Book_Categories on u.BookID equals cc.BookID into cct
                        from bcct in cct.DefaultIfEmpty()
                        join c in _context.Categories on bcct.CategoryID equals c.CategoryID into ct
                        from bct in ct.DefaultIfEmpty()
                             //.ThenInclude(tt => tt.Book_Translator)
                             //.ThenInclude(t=>t.Translator)
                         where (u.Book.Delete == false 
                         && u.Book.Title.Contains(title.TrimEnd().TrimStart())
                         && u.Book.ISBN.Contains(ISBN.TrimEnd().TrimStart())
                         && u.Book.publisher.PublisherName.Contains(Publisher.TrimEnd().TrimStart())
                         && l.LanguageName.Contains(Language.TrimEnd().TrimStart())
                         && EF.Functions.Like(l.LanguageName, "%" + Language + "%")
                         )
                         select new BooksIndexViewModel
                         {
                             Author = u.Author.FirstName + " " + u.Author.LastName,
                             Translator = bttc != null ? btc.Name + " " + btc.Family : "",
                             Category = bcct != null ? bct.CategoryName : "",
                             BookID = u.Book.BookID,
                             ISBN = u.Book.ISBN,
                             IsPublish = u.Book.IsPublish,
                             Price = u.Book.Price,
                             PublishDate = u.Book.PublishDate,
                             PublisherName = u.Book.publisher.PublisherName,
                             Stock = u.Book.Stock,
                             Title = u.Book.Title,
                             Language=l.LanguageName,
                         }).Where(a => a.Author.Contains(Author) && a.Translator.Contains(Translator) && a.Category.Contains(Category)).GroupBy(b => b.BookID).Select(g => new { BookID = g.Key, BookGroups = g }).ToList();
            foreach (var item in Books)
            {
                AuthorName = "";
                TranslatorName = "";
                CategoryName = "";
                foreach (var itemGroup in item.BookGroups.Select(a=>a.Author).Distinct())
                {
                    if (AuthorName == "")
                        AuthorName = itemGroup;
                    else
                        AuthorName = AuthorName + " - " + itemGroup;

                }
                foreach (var itemGroup in item.BookGroups.Select(a => a.Translator).Distinct())
                {
                    if (TranslatorName == "")
                        TranslatorName = itemGroup;
                    else
                        TranslatorName = TranslatorName + " - " + itemGroup;

                }
                foreach (var itemGroup in item.BookGroups.Select(a => a.Category).Distinct())
                {
                    if (CategoryName == "")
                        CategoryName = itemGroup;
                    else
                        CategoryName = CategoryName + " - " + itemGroup;
                }

                BooksIndexViewModel vm = new BooksIndexViewModel()
                {
                    Author = AuthorName,
                    Translator = TranslatorName,
                    Category = CategoryName,
                    BookID = item.BookID,
                    ISBN = item.BookGroups.First().ISBN,
                    IsPublish = item.BookGroups.First().IsPublish,
                    Price = item.BookGroups.First().Price,
                    PublishDate = item.BookGroups.First().PublishDate,
                    PublisherName = item.BookGroups.First().PublisherName,
                    Stock = item.BookGroups.First().Stock,
                    Title = item.BookGroups.First().Title,
                    Language = item.BookGroups.First().Language,
                };
                BooksViewModel.Add(vm);
            }
            return BooksViewModel;
        }

    }
}
