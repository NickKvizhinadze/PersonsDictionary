using Microsoft.Extensions.DependencyInjection;
using PersonsDictionary.Application.Cities;
using PersonsDictionary.Application.Common;
using PersonsDictionary.Persistence.Cities;
using PersonsDictionary.Persistence.Common;
using PersonsDictionary.Persistence.Persons;
using PersonsDictionary.Persistence.Reports;
using PersonsDictionary.Application.Persons.Abstractions;
using PersonsDictionary.Application.Reports.Abstractions;

namespace PersonsDictionary.Persistence
{
    public static class DataDependencyInjectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPersonsRepository, PersonsRepository>();
            services.AddTransient<IPersonRelationsRepository, PersonRelationsRepository>();
            services.AddTransient<IPhoneNumbersRepository, PhoneNumbersRepository>();
            services.AddTransient<ICitiesRepository, CitiesRepository>(); 
            services.AddTransient<IReportsRepository, ReportsRepository>(); 
        }

        public static void RegisterUnitOfWorks(this IServiceCollection services)
        {
            services.AddTransient<IBaseUow, BaseUow>();
            services.AddTransient<IPersonsUow, PersonsUow>();
            services.AddTransient<IReportsUow, ReportsUow>();
        }
    }
}
