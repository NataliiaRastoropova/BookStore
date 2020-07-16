using System;
using System.ComponentModel.DataAnnotations;
using BookStore.DB.Domain;

namespace BookStore.Shared.Dto.Book
{
    public sealed class BookViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Page Numbers")]
        public int PageNumbers { get; set; }
        [Display(Name = "PublishDate")]
        public DateTime PublishDate { get; set; }
        public string Publisher { get; set; }
        public string[] Authors { get; set; }
    }
}
