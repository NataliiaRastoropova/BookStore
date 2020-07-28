using BookStore.DB.Domain;
using BookStore.DB.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DB.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreContext context):base(context)
        { }

        public async Task<string> GetAuthorName(int id)
        {
            return await m_context.BookAuthors
                .Include(ba => ba.Author)
                .Where(a => a.AuthorId == id)
                .Select(a => $"{a.Author.LastName} {a.Author.FirstName}").FirstOrDefaultAsync();
        }
    }
}
