using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using PersonsDictionary.Application.Reports.Models.Dtos;
using PersonsDictionary.Application.Reports.Abstractions;

namespace PersonsDictionary.Application.Reports
{
    public class ReportsService : IReportsService
    {
        #region Fields
        private readonly IReportsUow _uow;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ReportsService(IReportsUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<PersonsRelationsCountByTypeDto>> GetPersonsRelationsCountByType()
        {
            var data = await _uow.Reports.GetPersonsRelationsCountByType();
            return _mapper.Map<List<PersonsRelationsCountByTypeDto>>(data);
        }
        #endregion
    }
}
