using System.Collections.Generic;

namespace PersonsDictionary.Common.Models
{
    public class ListResult<T> where T : class
    {
        public ListResult(List<T> persons, Paging paging)
        {
            Persons = persons;
            Paging = paging;
        }

        public List<T> Persons { get; private set; }

        public Paging Paging { get; private set; }
    }

    public class ListResult<T, TFilter> : ListResult<T> where T : class where TFilter : class
    {
        public ListResult(List<T> persons, TFilter filter, Paging paging) : base(persons, paging)
        {
            Filter = filter;
        }

        public TFilter Filter { get; private set; }
    }
}
