using AutoMapper;
using BookStore.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookStore.Shared
{
    public static class DependencyInjection
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(AuthorService));
            services.AddScoped(typeof(BookService));
            services.AddScoped(typeof(PublisherService));
        }
    }
}
