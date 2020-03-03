using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;
using PersonsDictionary.Domain.Reports;
using PersonsDictionary.Application.Reports.Abstractions;
using Microsoft.Extensions.Options;
using PersonsDictionary.Common.Models;

namespace PersonsDictionary.Persistence.Reports
{
    public class ReportsRepository : IReportsRepository
    {
        #region Fields
        private readonly string _connectionString;
        #endregion
        #region Constructor
        public ReportsRepository(IOptions<ConnectionStrings> options)
        {
            _connectionString = options.Value.DefaultConnection;
        }
        #endregion

        #region Methods
        public async Task<List<PersonsRelationCountByType>> GetPersonsRelationsCountByType()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM dbo.vGetPersonsRelationsCountByType";
                var data = await connection.QueryAsync<PersonsRelationCountByType>(query);
                return data.ToList();
            }
        }
        #endregion

    }
}
