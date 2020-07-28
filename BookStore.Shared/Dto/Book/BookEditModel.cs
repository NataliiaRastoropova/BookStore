using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Shared.Dto.Book
{
    public sealed class BookEditModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Title required!")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Genre required!")]
        public byte Genre { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Page numbers")]
        public int PageNumbers { get; set; }
        [Display(Name = "Publish date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }
        public int PublisherId { get; set; }
        public int[] AuthorsId { get; set; }
    }
}
