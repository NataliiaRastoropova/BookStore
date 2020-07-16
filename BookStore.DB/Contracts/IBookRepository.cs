using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DB.Domain;

namespace BookStore.DB.Repositories
{
    public interface IBookRepository
    {
        Task Add(Book entity);
        Task Update(Book entity);
        Task Delete(int id);
        Task<IReadOnlyCollection<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<IEnumerable<Book>> GetByPublisher(int id);
        Task<IEnumerable<Book>> GetByAuthor(int id);
    }
}
