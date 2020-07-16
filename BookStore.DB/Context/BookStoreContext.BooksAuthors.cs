using BookStore.DB.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DB
{
    public partial class BookStoreContext:DbContext
    {
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }

        private void BookAuthorConfiguration(ModelBuilder builder)
        {
            builder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId});

                entity.HasOne(e => e.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(e => e.BookId);

                entity.HasOne(e => e.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(e => e.AuthorId);
            });
        }
    }
}
