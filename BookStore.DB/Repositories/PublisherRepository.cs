using BookStore.DB.Domain;
using BookStore.DB.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DB.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookStoreContext context) :base(context)
        {}

        public async Task<string> GetPublisherName(int id)
        {
            return await m_context.Publishers.Where(p => p.Id == id)
                .Select(n => n.Name)
                .FirstOrDefaultAsync();
        }
    }
}
