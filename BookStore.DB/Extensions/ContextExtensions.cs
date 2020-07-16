using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BookStore.DB.Extensions
{
    public static class ContextExtensions
    {
        public static async Task AddOrUpdateAsync(this DbContext ctx, object entity)
        {
            try
            {
                var entry = ctx.Entry(entity);
                //if (entry.State is EntityState.Detached)
                //{
                //    ctx.Attach(entity);
                //}
                switch (entry.State)
                {
                    case EntityState.Detached:
                        await ctx.AddAsync(entity);
                        break;
                    case EntityState.Modified:
                        ctx.Update(entity);
                        break;
                    case EntityState.Added:
                        await ctx.AddAsync(entity);
                        break;
                    case EntityState.Unchanged:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } 
            catch (Exception e)
            {
                var tmp = e.Message;
            }
        }
    }
}
