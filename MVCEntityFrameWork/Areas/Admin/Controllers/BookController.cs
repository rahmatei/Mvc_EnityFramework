using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MVCEntityFrameWork.Models;
using MVCEntityFrameWork.Models.Repository;
using MVCEntityFrameWork.Models.ViewModels;
using ReflectionIT.Mvc.Paging;

namespace MVCEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly BookShopDBContext _context;
        private readonly BookRepository _repository;

        public BookController(BookShopDBContext context, BookRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public IActionResult Index(int page=1,int row=5,string sortExpression = "Title", string title="")
        {
            title = String.IsNullOrEmpty(title) ? "" : title;
            List<int> RowsCount = new List<int>()
            {
                5,10,15,20
            };
            ViewBag.RowID = new SelectList(RowsCount,row);
            ViewBag.NumOfPage = (page - 1) * row + 1;
            ViewBag.Search = title;

            var PagingModel = PagingList.Create(_repository.GetBooks(title,"","","","","",""), row, page, sortExpression, "Title");
            PagingModel.RouteValue = new RouteValueDictionary
            {
                {"row",row },
                {"title",title }
            };
            ViewBag.LanguageID = new SelectList(_context.Languages, "LanguageName", "LanguageName");
            ViewBag.PublisherID = new SelectList(_context.Publishers, "PublisherName", "PublisherName");
            ViewBag.AuthorID = new SelectList(_context.Authors.Select(t => new AuthorList { AuthorID = t.AuthorID, NameFamily = t.FirstName + " " + t.LastName }), "NameFamily", "NameFamily");
            ViewBag.TranslatorID = new SelectList(_context.Translator.Select(t => new TranslatorList { TranslatorID = t.TranslatorID, NameFamily = t.Name + " " + t.Family }), "NameFamily", "NameFamily");
            ViewBag.Categories = _repository.GenerateAllTree();
            return View(PagingModel);
        }
        public IActionResult AdvancedSearch(AdvancedSearchViewModel ViewModel)
        {
            ViewModel.Author = String.IsNullOrEmpty(ViewModel.Author) ? "" : ViewModel.Author;
            ViewModel.Category = String.IsNullOrEmpty(ViewModel.Category) ? "" : ViewModel.Category;
            ViewModel.ISBN = String.IsNullOrEmpty(ViewModel.ISBN) ? "" : ViewModel.ISBN;
            ViewModel.Language = String.IsNullOrEmpty(ViewModel.Language) ? "" : ViewModel.Language;
            ViewModel.Publisher = String.IsNullOrEmpty(ViewModel.Publisher) ? "" : ViewModel.Publisher;
            ViewModel.Title = String.IsNullOrEmpty(ViewModel.Title) ? "" : ViewModel.Title;
            ViewModel.Translator = String.IsNullOrEmpty(ViewModel.Translator) ? "" : ViewModel.Translator;
            var Books = _repository.GetBooks(ViewModel.Title, ViewModel.ISBN,
                                            ViewModel.Language, ViewModel.Publisher, ViewModel.Author
                                            , ViewModel.Translator, ViewModel.Category);
            return View(Books);
        }
        public IActionResult Create()
        {
            ViewBag.LanguageID = new SelectList(_context.Languages, "LanguageID", "LanguageName");
            ViewBag.PublisherID = new SelectList(_context.Publishers, "PublisherID", "PublisherName");
            ViewBag.AuthorID = new SelectList(_context.Authors.Select(t=>new AuthorList { AuthorID=t.AuthorID,NameFamily=t.FirstName+" " + t.LastName }) , "AuthorID", "NameFamily");
            ViewBag.TranslatorID = new SelectList(_context.Translator.Select(t => new TranslatorList { TranslatorID = t.TranslatorID, NameFamily = t.Name + " " + t.Family }), "TranslatorID", "NameFamily");
            BookCreateViewModel ViewModel = new BookCreateViewModel(_repository.GenerateAllTree());
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                List<Author_Book> author_Books = new List<Author_Book>();
                List<Book_Translator> translators = new List<Book_Translator>();
                List<Book_Category> categories = new List<Book_Category>();
                DateTime? PublishDate = null;
                if (ViewModel.IsPublish == true)
                {
                    PublishDate = DateTime.Now;
                }
                Book book = new Book()
                {
                    Delete = false,
                    ISBN = ViewModel.ISBN,
                    IsPublish = ViewModel.IsPublish,
                    NumOfPages = ViewModel.NumOfPages,
                    Stock = ViewModel.Stock,
                    Price = ViewModel.Price,
                    LanguageID = ViewModel.LanguageID,
                    Summary = ViewModel.Summary,
                    Title = ViewModel.Title,
                    PublishYear = ViewModel.PublishYear,
                    PublishDate = PublishDate,
                    Weight = ViewModel.Weight,
                    PublisherID = ViewModel.PublisherID
                };
                await _context.Books.AddAsync(book);
                if (ViewModel.AuthorID != null)
                {
                    for (int i = 0; i < ViewModel.AuthorID.Length; i++)
                    {
                        Author_Book author_Book = new Author_Book()
                        {
                            BookID = book.BookID,
                            AuthorID = ViewModel.AuthorID[i],
                        };
                        author_Books.Add(author_Book);
                    }
                }
                await _context.Author_Books.AddRangeAsync(author_Books);

                if (ViewModel.TranslatorID != null)
                {
                    for (int i = 0; i < ViewModel.TranslatorID.Length; i++)
                    {
                        Book_Translator translator = new Book_Translator()
                        {
                            BookID = book.BookID,
                            TranslatorID = ViewModel.TranslatorID[i],
                        };

                        translators.Add(translator);
                    }

                    await _context.Book_Translators.AddRangeAsync(translators);
                }

                if (ViewModel.CategoryID != null)
                {
                    for (int i = 0; i < ViewModel.CategoryID.Length; i++)
                    {
                        Book_Category category = new Book_Category()
                        {
                            BookID = book.BookID,
                            CategoryID = ViewModel.CategoryID[i],
                        };

                        categories.Add(category);
                    }

                    await _context.Book_Categories.AddRangeAsync(categories);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }
            else
            {

                ViewBag.LanguageID = new SelectList(_context.Languages, "LanguageID", "LanguageName");
                ViewBag.PublisherID = new SelectList(_context.Publishers, "PublisherID", "PublisherName");
                ViewBag.AuthorID = new SelectList(_context.Authors.Select(t => new AuthorList { AuthorID = t.AuthorID, NameFamily = t.FirstName + " " + t.LastName }), "AuthorID", "NameFamily");
                ViewBag.TranslatorID = new SelectList(_context.Translator.Select(t => new TranslatorList { TranslatorID = t.TranslatorID, NameFamily = t.Name + " " + t.Family }), "TranslatorID", "NameFamily");
                ViewModel.Categories = _repository.GenerateAllTree();

                return View(ViewModel);
            }
            
        }
    }
}
