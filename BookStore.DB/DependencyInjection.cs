using BookStore.DB.Domain;
using BookStore.DB.Repositories;
using BookStore.DB.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DB
{
    public static class DependencyInjection
    {
        public static void AddDateBase(this IServiceCollection services, string connectionString)
        {
            //services.Scan(scan =>
            //                scan.FromCallingAssembly()
            //        .AddClasses(classes => classes.AssignableTo<BaseRepository<BaseEntity>>())
            //        .AsImplementedInterfaces()
            //        .WithScopedLifetime());

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();

            services.AddDbContextPool<BookStoreContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
