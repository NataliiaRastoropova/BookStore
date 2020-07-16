using BookStore.DB.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DB
{
    public partial class BookStoreContext:DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        private void BooksConfiguration(ModelBuilder builder)
        {
            builder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Title).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Genre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PageNumbers).IsRequired();
                entity.Property(e => e.PublishDate).IsRequired();
                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(e => e.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(e => e.PublisherId);
            });
        }
    }
}
