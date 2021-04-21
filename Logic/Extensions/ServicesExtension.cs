using Logic.Services;
using Logic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.Extensions
{
    public static class ServicesExtension
    {
        public static void AddLogicServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchService, SearchService>();
        }
    }
}
