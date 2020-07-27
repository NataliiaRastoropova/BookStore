using System.ComponentModel.DataAnnotations;

namespace BookStore.Shared.Dto.Publisher
{
    public sealed class PublisherEditModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name required!")]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "City required!")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string City { get; set; }
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        [Required(ErrorMessage = "Country required!")]
        public string Country { get; set; }
    }
}
