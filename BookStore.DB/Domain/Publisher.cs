using System.Collections.Generic;

namespace BookStore.DB.Domain
{
    public class Publisher : BaseEntity
    {
        public string Name { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public virtual ICollection<Book> Books { get; set; }

        public Publisher()
        {
        }

        public Publisher(int? id, string name, string city, string country)
        {
            Id = id;
            Name = name;
            City = city;
            Country = country;
        }
    }
}
