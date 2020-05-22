using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Maps
{
    public class Author_BookMap: IEntityTypeConfiguration<Author_Book>
    {
        public void Configure(EntityTypeBuilder<Author_Book> Builder)
        {

            Builder.HasKey(k => new { k.AuthorID, k.BookID });

            Builder
                .HasOne(p => p.Book)
                .WithMany(t => t.Author_Books)
                .HasForeignKey(f => f.BookID);

            Builder
                .HasOne(p => p.Author)
                .WithMany(t => t.Author_Books)
                .HasForeignKey(f => f.AuthorID);

        }
    }
}
