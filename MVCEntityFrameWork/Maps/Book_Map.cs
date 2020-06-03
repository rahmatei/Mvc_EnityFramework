using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCEntityFrameWork.Models;

namespace MVCEntityFrameWork.Maps
{
    public class Book_Map:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> Builder)
        {

            Builder.HasKey(b => b.BookID);
            Builder.Property(b => b.Title).IsRequired();
            Builder.Property(b => b.Image).HasColumnType("image");

            Builder
                .HasOne(d => d.Discount)
                .WithOne(b => b.Book)
                .HasForeignKey<Discount>(f => f.BookID);
        }
    }
}
