using BookStore.DB.Domain;
using BookStore.DB.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DB.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookStoreContext context) :base(context)
        {}


    }
}
