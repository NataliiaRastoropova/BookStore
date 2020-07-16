using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStore.DB.Domain;
using BookStore.DB.Repositories.Core;
using System;

namespace BookStore.DB.Repositories
{
    public class BookRepository: BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext context) :base(context)
        {}

        public async Task<IEnumerable<Book>> GetByPublisher(int id)
        {
            return await m_context.Books.Where(p => p.PublisherId == id).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByAuthor(int id)
        {
            return await (from ba in m_context.BookAuthors
                          join book in m_context.Books
                            on ba.BookId equals book.Id
                          join author in m_context.Authors
                            on ba.AuthorId equals author.Id
                          where author.Id == id
                          select book).ToListAsync();
        }
    }
}
