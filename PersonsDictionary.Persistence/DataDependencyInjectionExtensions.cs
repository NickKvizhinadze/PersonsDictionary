using Microsoft.Extensions.DependencyInjection;
using PersonsDictionary.Application.Cities;
using PersonsDictionary.Application.Common;
using PersonsDictionary.Application.Persons;
using PersonsDictionary.Persistence.Cities;
using PersonsDictionary.Persistence.Common;
using PersonsDictionary.Persistence.Persons;
using PersonsDictionary.Persistence.Repositories;

namespace PersonsDictionary.Persistence
{
    public static class DataDependencyInjectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPersonsRepository, PersonsRepository>();
            services.AddTransient<IMobileNumbersRepository, MobileNumbersRepository>();
            services.AddTransient<ICitiesRepository, CitiesRepository>();
        }

        public static void RegisterUnitOfWorks(this IServiceCollection services)
        {
            services.AddTransient<IBaseUow, BaseUow>();
            services.AddTransient<IPersonsUow, PersonsUow>();
        }
    }
}
