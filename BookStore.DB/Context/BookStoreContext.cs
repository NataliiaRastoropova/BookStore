using BookStore.DB.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DB
{
    public partial class BookStoreContext:DbContext
    {
    //    public DbSet<Book> Books { get; set; }
    //    public DbSet<Author> Authors { get; set; }
    //    public DbSet<Publisher> Publishers { get; set; }

        public BookStoreContext(DbContextOptions options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BooksConfiguration(modelBuilder);
            AuthorsConfiguration(modelBuilder);
            BookAuthorConfiguration(modelBuilder);
            PublishersConfiguration(modelBuilder);
        }
    }
}
