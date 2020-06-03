using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Maps
{
    public class Book_CategoryMap : IEntityTypeConfiguration<Book_Category>
    {
        public void Configure(EntityTypeBuilder<Book_Category> builder)
        {
            builder.HasKey(t => new { t.BookID, t.CategoryID });
            builder.HasOne(p => p.Book)
                .WithMany(t => t.Book_Categories)
                .HasForeignKey(f => f.BookID);

            builder.HasOne(p => p.Category)
                .WithMany(t => t.Book_Categories)
                .HasForeignKey(f => f.CategoryID);
        }
    }
}
