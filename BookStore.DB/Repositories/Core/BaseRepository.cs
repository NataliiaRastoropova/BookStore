using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.DB.Domain;

namespace BookStore.DB.Repositories.Core
{
    /// <summary>
    /// Base repository class
    /// </summary>
    /// <typeparam name="TE">Entity class</typeparam>
    public abstract class BaseRepository<TE> where TE : BaseEntity
    {
        protected readonly BookStoreContext m_context;

        public BaseRepository(BookStoreContext context)
        {
            this.m_context = context;
        }

        public async Task Add(TE entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            m_context.Add(entity);
            await m_context.SaveChangesAsync();
        }

        public async Task Update(TE entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            m_context.Update(entity);
            await m_context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            this.m_context.Remove(await GetById(id));
            await m_context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<TE>> GetAll()
        {
            return await this.m_context.Set<TE>().ToListAsync();
        }

        public async Task<TE> GetById(int id)
        {
            return await this.m_context.Set<TE>()
                    .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
