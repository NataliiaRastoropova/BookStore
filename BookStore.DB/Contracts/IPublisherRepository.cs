using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DB.Domain;

namespace BookStore.DB.Repositories
{
    public interface IPublisherRepository
    {
        Task Add(Publisher entity);
        Task Update(Publisher entity);
        Task Delete(int id);
        Task<IReadOnlyCollection<Publisher>> GetAll();
        Task<Publisher> GetById(int id);
    }
}
