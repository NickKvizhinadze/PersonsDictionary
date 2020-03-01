﻿using System.Threading.Tasks;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonsRepository : IBaseRepository<Person, int>
    {
        Task<string> GetImageUrlAsync(int id);
    }
}