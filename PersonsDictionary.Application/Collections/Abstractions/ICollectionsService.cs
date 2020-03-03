using PersonsDictionary.Application.Collections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Application.Collections.Abstractions
{
    public interface ICollectionsService
    {
        Task<List<CollectionDto<int>>> GetPersonsAsync();
        List<CollectionDto<int>> GetGenders();
        List<CollectionDto<int>> GetPersonRelationTypes();
        List<CollectionDto<int>> GetPhoneNumberTypes();
    }
}
