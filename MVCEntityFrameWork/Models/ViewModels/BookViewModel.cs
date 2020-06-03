using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Models.ViewModels
{
    public class BookCreateViewModel
    {
        public BookCreateViewModel(IEnumerable<TreeViewCategory> categories)
        {
            Categories = categories;
        }

        public BookCreateViewModel()
        {
        }

        public string Title { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string File { get; set; }

        public int NumOfPages { get; set; }
        public short Weight { get; set; }
        public string ISBN { get; set; }
        public bool IsPublish { get; set; }
        public int LanguageID { get; set; }
        public int PublisherID { get; set; }
        public int[] AuthorID { get; set; }
        public int[] TranslatorID { get; set; }
        public int[] CategoryID { get; set; }

        public IEnumerable<TreeViewCategory> Categories { get; set; }

    }
    public class AuthorList
    {
        public int AuthorID { get; set; }
        public string NameFamily { get; set; }
    }
    public class TranslatorList
    {
        public int TranslatorID { get; set; }
        public string NameFamily { get; set; }
    }
}
