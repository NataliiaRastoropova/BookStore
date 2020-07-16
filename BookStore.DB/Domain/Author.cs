using System;
using System.Collections.Generic;

namespace BookStore.DB.Domain
{
    public class Author: BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime Birthday { get; private set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public Author()
        { }
        public Author(int? id, string firstName, string lastName, string phoneNumber, DateTime birthday)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
        }

    }
}