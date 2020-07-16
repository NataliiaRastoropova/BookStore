using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using BookStore.DB.Domain;
using BookStore.DB.Repositories;
using BookStore.Shared.Dto.Author;

namespace BookStore.Shared.Services
{
    public sealed class AuthorService
    {
        private IAuthorRepository m_repository;
        private IMapper m_automapper;

        public AuthorService(IAuthorRepository repository, IMapper automapper)
        {
            m_repository = repository;
            m_automapper = automapper;
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAll()
        {
            return (await m_repository.GetAll())
                .Select(m => m_automapper.Map<AuthorViewModel>(m));
        }

        public async Task Create(AuthorCreateModel model)
        {
            await m_repository.Add(m_automapper.Map<Author>(model));
        }

        public async Task Update(AuthorEditModel model)
        { 
            await m_repository.Update(m_automapper.Map<Author>(model));
        }

        public async Task Delete(int id)
        {
            await m_repository.Delete(id);
        }

        public async Task<AuthorEditModel> GetById(int id)
        {
            var model = await m_repository.GetById(id);
            return m_automapper.Map<AuthorEditModel>(model);
        }
    }
}
