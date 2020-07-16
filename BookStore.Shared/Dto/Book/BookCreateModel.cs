using System;
using System.ComponentModel.DataAnnotations;
using BookStore.DB.Domain;

namespace BookStore.Shared.Dto.Book
{
    public sealed class BookCreateModel
    {
        [Required(ErrorMessage = "Title Required!")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Genre Required!")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Genre { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        [Display(Name = "Page Numbers")]
        public int PageNumbers { get; set; }
        [Display(Name = "Publish Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }
        public int PublisherId { get; set; }
        public int[] AuthorsId { get; set; }
    }
}
