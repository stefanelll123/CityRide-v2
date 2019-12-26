using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CityRide.Infrastructure
{
    public class Result
    {
        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;

        public List<string> ErrorMessages { get; set; } = new List<string>();

        public bool HasErrors => this.ErrorMessages.Any();

        public bool Success => !this.HasErrors;

        public static Result Ok()
        {
            return new Result();
        }

        public static Result<T> Ok<T>(T data)
        {
            return new Result<T>
            {
                Data = data
            };
        }

        public static Result Error(HttpStatusCode statusCode, string message)
        {
            var result = new Result { HttpStatusCode = statusCode };
            result.ErrorMessages.Add(message);

            return result;
        }

        public static Result<T> Error<T>(HttpStatusCode statusCode, string message)
        {
            var result = new Result<T>(statusCode);
            result.ErrorMessages.Add(message);

            return result;
        }
    }

    public class Result<T> : Result
    {
        public Result() { }

        public Result(HttpStatusCode statusCode) : this()
        {
            this.HttpStatusCode = statusCode;
        }

        public Result(HttpStatusCode statusCode, IEnumerable<string> errors) : this(statusCode)
        {
            this.ErrorMessages.AddRange(errors);
        }

        public T Data { get; set; }
    }
}
