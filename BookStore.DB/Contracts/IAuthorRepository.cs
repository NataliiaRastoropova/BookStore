using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DB.Domain;

namespace BookStore.DB.Repositories
{
    public interface IAuthorRepository
    {
        Task Add(Author entity);
        Task Update(Author entity);
        Task Delete(int id);
        Task<IReadOnlyCollection<Author>> GetAll();
        Task<Author> GetById(int id);
    }
}
