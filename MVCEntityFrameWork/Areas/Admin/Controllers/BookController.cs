using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCEntityFrameWork.Models;
using MVCEntityFrameWork.Models.Repository;
using MVCEntityFrameWork.Models.ViewModels;

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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            var Categories = (from c in _context.Categories
                              where (c.ParentCategoryID == null)
                              select new TreeViewCategory { CategoryID = c.CategoryID, CategoryName = c.CategoryName }).ToList();

            foreach (var item in Categories)
            {
                _repository.BindSubCategory(item);
            }

            ViewBag.LanguageID = new SelectList(_context.Languages, "LanguageID", "LanguageName");
            ViewBag.PublisherID = new SelectList(_context.Publishers, "PublisherID", "PublisherName");
            ViewBag.AuthorID = new SelectList(_context.Authors.Select(t=>new AuthorList { AuthorID=t.AuthorID,NameFamily=t.FirstName+" " + t.LastName }) , "AuthorID", "NameFamily");
            ViewBag.TranslatorID = new SelectList(_context.Translator.Select(t => new TranslatorList { TranslatorID = t.TranslatorID, NameFamily = t.Name + " " + t.Family }), "TranslatorID", "NameFamily");


            BookCreateViewModel ViewModel = new BookCreateViewModel(Categories);

            return View(ViewModel);
        }
    }
}
