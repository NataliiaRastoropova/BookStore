using System;
using System.Collections.Generic;

namespace BookStore.DB.Domain
{
    public class Book: BaseEntity
    {
        public string Title { get; private set; }
        public Genre Genre { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public decimal Price { get; private set; }
        public int PageNumbers { get; private set; }
        public DateTime PublishDate { get; private set; }
        public int PublisherId { get; private set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public Book()
        { }
        public Book(int? id, string title, Genre genre, decimal price, int pageNumbers, DateTime publishDate, int publisherId)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Price = price;
            PageNumbers = pageNumbers;
            PublishDate = publishDate;
            PublisherId = publisherId;
        }
    }
}
