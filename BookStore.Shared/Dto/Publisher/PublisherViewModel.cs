using BookStore.Shared.Dto.Book;
using System.Collections.Generic;

namespace BookStore.Shared.Dto.Publisher
{
    public sealed class PublisherViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
