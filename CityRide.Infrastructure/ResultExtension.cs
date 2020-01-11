using System;
using System.Threading.Tasks;

namespace CityRide.Infrastructure
{
    public static class ResultExtension
    {
        public static Result Map<TEntity, TResult>(this Result result, Func<TEntity, TResult> mapFunc)
        {
            var returnResult = new Result<TResult>();
            if (result.HasErrors)
            {
                return result;
            }

            returnResult.Data = mapFunc((result as Result<TEntity>).Data);

            return returnResult;
        }

        public static async Task<Result> Map<TEntity, TResult>(this Task<Result> result, Func<TEntity, TResult> mapFunc)
        {
            var awaitResult = await result;
            var returnResult = new Result<TResult>();
            if (awaitResult.HasErrors)
            {
                return awaitResult;
            }

            var resultGeneric = awaitResult as Result<TEntity>;
            if(resultGeneric == null)
            {
                return returnResult;
            }

            returnResult.Data = mapFunc(resultGeneric.Data);

            return returnResult;
        }

        public static Result And(this Result result, Func<Result> otherFunc)
        {
            if (result.HasErrors)
            {
                return result;
            }

            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);

            return result;
        }

        public static async Task<Result> And(this Result result, Func<Task<Result>> otherFunc)
        {
            if (result.HasErrors)
            {
                return result;
            }

            return await otherFunc();
        }
    }
}
