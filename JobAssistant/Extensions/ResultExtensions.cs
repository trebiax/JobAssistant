using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobAssistant.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            var statusCode = result.IsFailure 
                ? HttpStatusCode.BadRequest 
                : HttpStatusCode.OK;

            object? value = result.IsFailure
                ? result.Error
                : result.Value;

            return new ObjectResult(value)
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
