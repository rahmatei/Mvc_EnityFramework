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
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var translate = await _context.Translator.FirstOrDefaultAsync(p => p.TranslatorID == id);
                if (translate == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(translate);
                }
                
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Translator translator)
        {
            if (ModelState.IsValid)
            {
                _context.Translator.Update(translator);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(translator);
        }
    }
}