using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Maps
{
    public class Book_TranslatorMap : IEntityTypeConfiguration<Book_Translator>
    {
        public void Configure(EntityTypeBuilder<Book_Translator> builder)
        {
            builder.HasKey(k => new { k.BookID, k.TranslatorID });

            builder.HasOne(p => p.Book)
                .WithMany(t => t.Book_Translator)
                .HasForeignKey(p => p.BookID);

            builder.HasOne(p => p.Translator)
                .WithMany(t => t.Book_Translator)
                .HasForeignKey(p => p.TranslatorID);


        }
    }
}
