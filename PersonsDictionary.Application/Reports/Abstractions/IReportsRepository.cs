using PersonsDictionary.Domain.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Application.Reports.Abstractions
{
    public interface IReportsRepository
    {
        Task<List<PersonsRelationCountByType>> GetPersonsRelationsCountByType();
    }
}
