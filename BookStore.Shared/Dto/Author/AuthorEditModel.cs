using BookStore.Shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Shared.Dto.Author
{
    public sealed class AuthorEditModel
    {
        public int? Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name required!")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name required!")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [MinimumAge(18)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}
