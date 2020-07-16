using BookStore.DB.Domain;
using BookStore.DB.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DB.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreContext context):base(context)
        { }
    }
}
