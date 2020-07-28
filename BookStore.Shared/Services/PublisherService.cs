using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using BookStore.DB.Repositories;
using BookStore.Shared.Dto.Publisher;
using BookStore.DB.Domain;
using System;

namespace BookStore.Shared.Services
{
    public sealed class PublisherService
    {
        private IPublisherRepository m_repository;
        private IMapper m_automapper;

        public PublisherService(IPublisherRepository repository, IMapper automapper)
        {
            m_repository = repository;
            m_automapper = automapper;
        }

        public async Task<IEnumerable<PublisherViewModel>> GetAll()
        {
            var publishers = await m_repository.GetAll();
            return (await m_repository.GetAll())
                    .Select(m => m_automapper.Map<PublisherViewModel>(m));
        }

        public async Task Create(PublisherCreateModel model)
        {
            await m_repository.Add(m_automapper.Map<Publisher>(model));
        }

        public async Task Update(PublisherEditModel model)
        {
            await m_repository.Update(m_automapper.Map<Publisher>(model));
        }

        public async Task Delete(int id)
        {
            await m_repository.Delete(id);
        }

        public async Task<PublisherEditModel> GetById(int id)
        {
            var model = await m_repository.GetById(id);
            return m_automapper.Map<PublisherEditModel>(model);
        }

        public async Task<string> GetPublisherName(int id)
        {
            return await m_repository.GetPublisherName(id);
        }
    }
}
