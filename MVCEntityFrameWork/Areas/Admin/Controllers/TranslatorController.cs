using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEntityFrameWork.Models;

namespace MVCEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TranslatorController : Controller
    {
        public readonly BookShopDBContext _context;

        public TranslatorController(BookShopDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Translator.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Translator translator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(translator);
                await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
            }
            return View(translator);
        }
    }
}