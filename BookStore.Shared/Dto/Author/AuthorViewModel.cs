using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Shared.Dto.Author
{
    public sealed class AuthorViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}
