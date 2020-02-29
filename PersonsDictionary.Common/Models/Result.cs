using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Common.Models
{
    public class Result
    {
        #region Properties
        public bool Succeeded => Errors == null || Errors.Count == 0;
        public List<KeyValuePair<string, string>> Errors { get; private set; }
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.OK;
        #endregion

        #region Methods
        public void AddError(string errorMessage, HttpStatusCode statusCode) =>
            AddError("Error", errorMessage, statusCode);

        public void AddError(string errorMessage) =>
            AddError("Error", errorMessage);


        public void AddError(string key, string errorMessage, HttpStatusCode statusCode) =>
            AddError(new KeyValuePair<string, string>(key, errorMessage), statusCode);

        public void AddError(string key, string errorMessage) =>
            AddError(new KeyValuePair<string, string>(key, errorMessage));


        public void AddError(KeyValuePair<string, string> error) =>
            AddError(error, HttpStatusCode.BadRequest);

        public void AddError(KeyValuePair<string, string> error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (StatusCode != statusCode)
                StatusCode = statusCode;
            if (Errors == null)
                Errors = new List<KeyValuePair<string, string>>();
            Errors.Add(error);
        }


        public void AddError(Dictionary<string, string> errors)
        {
            foreach (var error in errors)
                AddError(error.Key, error.Value);
        }


        public void AddErrors(List<string> errorMessages)
        {
            foreach (var errorMessage in errorMessages)
                AddError(errorMessage);
        }

        public void AddErrors(IEnumerable<KeyValuePair<string, string>> errors)
        {
            foreach (var error in errors)
                AddError(error.Key, error.Value);
        }

        #endregion
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
