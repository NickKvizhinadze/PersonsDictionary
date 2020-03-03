using PersonsDictionary.Application.Reports.Abstractions;
using PersonsDictionary.Persistence.Common;

namespace PersonsDictionary.Persistence.Reports
{
    public class ReportsUow : BaseUow, IReportsUow
    {
        public ReportsUow(ApplicationDbContext context, IReportsRepository reports) : base(context)
        {
            Reports = reports;
        }
        #region Constructor

        #endregion

        #region Properties
        public IReportsRepository Reports { get; private set; }
        #endregion
    }
}
