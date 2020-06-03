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

        public void BindSubCategory(TreeViewCategory category)
        {
            var subcategory = (from c in _context.Categories
                               where (c.ParentCategoryID == category.CategoryID)
                               select new TreeViewCategory { CategoryID = c.CategoryID, CategoryName = c.CategoryName });
            foreach (var item in subcategory)
            {
                BindSubCategory(item);
                category.SubCategories.Add(item);
            }
        }

    }
}
