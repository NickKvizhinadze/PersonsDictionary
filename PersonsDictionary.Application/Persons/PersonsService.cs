using AutoMapper;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PersonsDictionary.Common.Helpers;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Localization;

namespace PersonsDictionary.Application.Persons
{
    public class PersonsService : IPersonsService
    {
        #region Constants
        private const string Dir = "persons";
        #endregion

        #region Fields
        private readonly IPersonsUow _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonsService> _logger;
        #endregion

        #region Constructor
        public PersonsService(IPersonsUow uow, IMapper mapper, ILogger<PersonsService> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Methods

        public async Task<Result<int>> AddAsync(PersonCreateRequest model, string webRootDir, int id = 0)
        {
            var result = new Result<int>();
            string imageUrl = null;
            try
            {
                var person = _mapper.Map<Person>(model);

                if (model.Image != null)
                {
                    imageUrl = await ImageManager.UploadImageAsync(model.Image, webRootDir, Dir);
                    person.ImageUrl = imageUrl;
                }

                if (id > 0)
                {
                    person.Id = id;
                    _uow.Persons.Update(person);
                }
                else
                    _uow.Persons.Add(person);

                await _uow.SaveAsync();
                _logger.LogInformation($"{nameof(PersonsService)} => {nameof(AddAsync)} | Person added successfully | Id: {id}");
                result.Data = person.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(PersonsService)} => {nameof(AddAsync)} | Person have not added successfully | Id: {id} | ex: {ex.ToString()} | trace: {ex.StackTrace.ToString()}");
                if (!string.IsNullOrEmpty(imageUrl))
                    ImageManager.DeleteImage(imageUrl, webRootDir, Dir);

                result.AddError(ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
            }
            return result;
        }

        #endregion
    }
}
