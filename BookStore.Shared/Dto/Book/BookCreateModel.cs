using System;
using System.ComponentModel.DataAnnotations;
using BookStore.DB.Domain;

namespace BookStore.Shared.Dto.Book
{
    public sealed class BookCreateModel
    {
        [Required(ErrorMessage = "Title required!")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Required(ErrorMessage = "Description required.")]
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Price required.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Price; Max 18 digits")]
        public decimal Price { get; set; }
        [Display(Name = "Page numbers")]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PageNumbers { get; set; }
        [Display(Name = "Publish date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }
        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }
        [Display(Name = "Authors")]
        public int[] AuthorsId { get; set; }
    }
}
