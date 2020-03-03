using Microsoft.Extensions.DependencyInjection;
using PersonsDictionary.Application.Persons;
using PersonsDictionary.Application.Reports;
using PersonsDictionary.Application.Collections;
using PersonsDictionary.Application.Persons.Abstractions;
using PersonsDictionary.Application.Reports.Abstractions;
using PersonsDictionary.Application.Collections.Abstractions;

namespace PersonsDictionary.Application
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonsService, PersonsService>();
            services.AddTransient<IReportsService, ReportsService>();
            services.AddTransient<ICollectionsService, CollectionsService>();
        }
    }
}
