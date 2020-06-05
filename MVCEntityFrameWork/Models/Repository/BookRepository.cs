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

    }
}
