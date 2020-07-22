using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using BookStore.DB.Domain;
using BookStore.DB.Repositories;
using BookStore.Shared.Dto.Book;
using BookStore.Shared.Dto.Publisher;

namespace BookStore.Shared.Services
{
    public sealed class BookService
    {
        private IBookRepository m_repository;
        private IMapper m_automapper;

        public BookService(IBookRepository repository, IMapper automapper)
        {
            m_repository = repository;
            m_automapper = automapper;
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var model = await m_repository.GetAll();
            return  model.Select(m => m_automapper.Map<BookViewModel>(m));
        }

        public async Task Create(BookCreateModel model)
        {
            await m_repository.Add(m_automapper.Map<Book>(model));
        }

        public async Task Update(BookEditModel model)
        {
            await m_repository.Update(m_automapper.Map<Book>(model));
        }

        public async Task Delete(int id)
        {
            await m_repository.Delete(id);
        }

        public async Task<IEnumerable<BookViewModel>> GetByPublisher(int id)
        {
            return (await m_repository.GetByPublisher(id))
                .Select(m => m_automapper.Map<BookViewModel>(m));
        }

        public async Task<IEnumerable<BookViewModel>> GetByAuthor(int id)
        {
            return (await m_repository.GetByAuthor(id))
                .Select(m => m_automapper.Map<BookViewModel>(m));
        }

        public async Task<BookEditModel> GetById(int id)
        {
            var model = await m_repository.GetById(id);
            return m_automapper.Map<BookEditModel>(model);
        }
    }
}
