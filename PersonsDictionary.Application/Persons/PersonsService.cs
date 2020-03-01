using AutoMapper;
using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PersonsDictionary.Localization;
using PersonsDictionary.Common.Helpers;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Persons.Models;
using PersonsDictionary.Application.Persons.Abstractions;

namespace PersonsDictionary.Application.Persons
{
    public class PersonsService : IPersonsService
    {
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
                    var existingNumbers = await _uow.PhoneNumbers.GetByPersonIdAsync(id);

                    person.Id = id;
                    person.ImageUrl = await _uow.Persons.GetImageUrlAsync(person.Id);

                    if (person.PhoneNumbers?.Any() == true)
                    {
                        var numbersToDelete = existingNumbers.Where(en => en.Id != 0 && person.PhoneNumbers.All(n => n.Id != en.Id));
                        if (numbersToDelete.Any())
                            _uow.PhoneNumbers.DeleteRange(numbersToDelete);

                        var numbersToUpdate = person.PhoneNumbers.Where(n => n.Id != 0 && existingNumbers.Any(en => en.Id == n.Id));
                        if (numbersToUpdate.Any())
                            _uow.PhoneNumbers.UpdateRange(numbersToUpdate);

                        var numbersToAdd = person.PhoneNumbers.Where(n => n.Id == 0);
                        if (numbersToAdd.Any())
                            _uow.PhoneNumbers.AddRange(numbersToAdd);
                    }

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

        public async Task<Result> DeleteAsync(int id, string webRoot)
        {
            var result = new Result();
            using (var transaction = await _uow.BeginTransactionAsync())
            {
                try
                {
                    var person = await _uow.Persons.GetByIdAsync(id);
                    if (person != null)
                    {
                        string imageUrl = person.ImageUrl;
                        _uow.Persons.Delete(person);

                        await _uow.SaveAsync();
                        ImageManager.DeleteImage(webRoot, imageUrl);
                        await transaction.CommitAsync();
                        _logger.LogError($"{nameof(PersonsService)} => {nameof(DeleteAsync)} | Person deleted successfully | Id: {id}");
                    }
                    else
                    {
                        result.AddError(ErrorMessages.PersonNotFound);
                        await transaction.RollbackAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{nameof(PersonsService)} => {nameof(DeleteAsync)} | Person have not deleted | Id: {id} | ex: {ex.ToString()} | trace: {ex.StackTrace.ToString()}");

                    result.AddError(ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
                    await transaction.RollbackAsync();
                }

                return result;
            }
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

                imageUrl = await ImageManager.UploadImageAsync(image, webRootDir);

                person.ImageUrl = imageUrl;
                _uow.Persons.Update(person);
                await _uow.SaveAsync();

                _logger.LogInformation($"{nameof(PersonsService)} => {nameof(UploadPhotoAsync)} | Photo added to person | Id: {id}");
                result.Data = imageUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(PersonsService)} => {nameof(UploadPhotoAsync)} | Photo have not added to person| Id: {id} | ex: {ex.ToString()} | trace: {ex.StackTrace.ToString()}");
                if (!string.IsNullOrEmpty(imageUrl))
                    ImageManager.DeleteImage(imageUrl, webRootDir);

                result.AddError(ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
            }
            return result;
        }

        public async Task<Result<int>> AddedRelatedPersonAsync(int id, RelatedPersonCreateRequest model)
        {
            var result = new Result<int>();
            try
            {
                var person = await _uow.Persons.GetByIdAsync(id);
                if (person == null)
                {
                    result.AddError(ErrorMessages.PersonNotFound);
                    return result;
                }
                var relatedPerson = await _uow.Persons.GetByIdAsync(model.RelatedPersonId);
                if (relatedPerson == null)
                {
                    result.AddError(ErrorMessages.RelatedPersonNotFound);
                    return result;
                }

                var relation = new PersonRelation
                {
                    PersonId = id,
                    RelatedPersonId = model.RelatedPersonId,
                    Type = model.Type
                };
                _uow.PersonRelations.Add(relation);

                await _uow.SaveAsync();
                result.Data = relation.Id;
                _logger.LogError($"{nameof(PersonsService)} => {nameof(AddedRelatedPersonAsync)} | Relation Added to person | Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(PersonsService)} => {nameof(AddedRelatedPersonAsync)} | Relation have not added to person | Id: {id} | ex: {ex.ToString()} | trace: {ex.StackTrace.ToString()}");
                result.AddError(ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
            }

            return result;
        }

        public async Task<Result> DeleteRelationAsync(int id)
        {
            var result = new Result();
            try
            {
                var relation = await _uow.PersonRelations.GetByIdAsync(id);
                if (relation == null)
                {
                    result.AddError(ErrorMessages.RelationNotFound);
                    return result;
                }

                _uow.PersonRelations.Delete(relation);
                await _uow.SaveAsync();
                _logger.LogError($"{nameof(PersonsService)} => {nameof(DeleteRelationAsync)} | Relation Added | Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(PersonsService)} => {nameof(DeleteRelationAsync)} | Relation have not deleted | Id: {id} | ex: {ex.ToString()} | trace: {ex.StackTrace.ToString()}");
                result.AddError(ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
            }

            return result;
        }

        #endregion
    }
}
