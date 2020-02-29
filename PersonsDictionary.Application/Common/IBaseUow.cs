using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Application.Common
{
    public interface IBaseUow : IDisposable
    {
        int Save();
        Task<int> SaveAsync();
    }
}
