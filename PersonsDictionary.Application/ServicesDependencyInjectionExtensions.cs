using Microsoft.Extensions.DependencyInjection;
using PersonsDictionary.Application.Persons;
using PersonsDictionary.Application.Persons.Abstractions;

namespace PersonsDictionary.Application
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonsService, PersonsService>();
        }
    }
}
