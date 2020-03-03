using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Reports.Abstractions
{
    public interface IReportsUow : IBaseUow
    {
        IReportsRepository Reports { get; }
    }
}
