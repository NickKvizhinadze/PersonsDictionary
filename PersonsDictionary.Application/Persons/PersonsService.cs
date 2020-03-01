﻿using AutoMapper;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PersonsDictionary.Common.Helpers;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Localization;
using Microsoft.AspNetCore.Http;

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

        public async Task<Result<int>> UpdateAsync(PersonCreateRequest model, int id = 0)
        {
            var result = new Result<int>();
            try
            {
                var person = _mapper.Map<Person>(model);

                if (id > 0)
                {
                    person.Id = id;
                    person.ImageUrl = await _uow.Persons.GetImageUrlAsync(id);
                    _uow.Persons.Update(person);
                }
                else
                    _uow.Persons.Add(person);

                await _uow.SaveAsync();
                _logger.LogInformation($"{nameof(PersonsService)} => {nameof(UpdateAsync)} | Person added successfully | Id: {id}");
                result.Data = person.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(PersonsService)} => {nameof(UpdateAsync)} | Person have not added successfully | Id: {id} | ex: {ex.ToString()} | trace: {ex.StackTrace.ToString()}");

                result.AddError(ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
            }
            return result;
        }


        public async Task<Result<string>> UploadPhotoAsync(int id, IFormFile image, string webRootDir)
        {
            var result = new Result<string>();
            string imageUrl = null;
            try
            {
                if (image == null)
                {
                    result.AddError(ErrorMessages.ImageIsRequired);
                    return result;
                }

                var person = await _uow.Persons.GetByIdAsync(id);
                if (person == null)
                {
                    result.AddError(ErrorMessages.PersonNotFound);
                    return result;
                }

                imageUrl = await ImageManager.UploadImageAsync(image, webRootDir, Dir);

                person.ImageUrl = imageUrl;
                _uow.Persons.Update(person);
                await _uow.SaveAsync();

                _logger.LogInformation($"{nameof(PersonsService)} => {nameof(UpdateAsync)} | Photo added to person | Id: {id}");
                result.Data = imageUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(PersonsService)} => {nameof(UpdateAsync)} | Photo have not added to person| Id: {id} | ex: {ex.ToString()} | trace: {ex.StackTrace.ToString()}");
                if (!string.IsNullOrEmpty(imageUrl))
                    ImageManager.DeleteImage(imageUrl, webRootDir, Dir);

                result.AddError(ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
            }
            return result;
        }

        #endregion
    }
}
