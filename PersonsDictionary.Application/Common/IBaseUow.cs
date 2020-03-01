using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace PersonsDictionary.Application.Common
{
    public interface IBaseUow : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        int Save();
        Task<int> SaveAsync();
    }
}
