using System.Threading.Tasks;
using System.Collections.Generic;
using PersonsDictionary.Application.Reports.Models.Dtos;

namespace PersonsDictionary.Application.Reports.Abstractions
{
    public interface IReportsService
    {
        Task<List<PersonsRelationsCountByTypeDto>> GetPersonsRelationsCountByType();
    }
}
