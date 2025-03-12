using Domain.Shared;

namespace API.Extensions
{
    public static class ResultExtension
    {
        public static IResult ToProblemDetails(this Result result)
        {
            if (result.Success)
            {
                throw new InvalidOperationException();
            }
            return Results.Problem(
                statusCode: GetStatusCode(result.Error.ErrorCode),
                title: GetTitle(result.Error.ErrorCode),
                extensions: new Dictionary<string, object?>
                {
                    {"errors", new [] { result.Error} }
                });

            #region Local function 
            //Mapping ErrorType to StatusCode
            static int GetStatusCode(ErrorType errorType)
                => errorType switch
                {
                    ErrorType.BadRequest => StatusCodes.Status400BadRequest,
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Conflict => StatusCodes.Status409Conflict,
                    _ => StatusCodes.Status500InternalServerError
                };
            //Get ErrorType title
            static string GetTitle(ErrorType errorType) 
                => errorType switch 
                {
                    ErrorType.BadRequest => "Bad Request",
                    ErrorType.NotFound => "Not Found",
                    ErrorType.Conflict => "Conflict",
                    _ => "Server Failure"
                };
            #endregion
        }

    }
}
