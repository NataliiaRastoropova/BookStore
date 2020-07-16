using System;
using System.Collections.Generic;
using BookStore.Shared.Dto.Book;

namespace BookStore.Shared.Dto.Author
{
    public sealed class AuthorViewModel
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
