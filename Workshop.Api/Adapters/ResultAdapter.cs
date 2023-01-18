using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Workshop.Api.DTO;
using Workshop.Domain.Contracts.Results;

namespace Workshop.Api.Adapters;

public class ResultAdapter<S>
{
    public static IActionResult Parse(GenericResult result)
    {
        var message = new MessageResponse(result.Message);

        if (result is SuccessResult)
        {
            if (result.Result != null)
            {
                return new OkObjectResult((S) result.Result);
            }

            return new OkObjectResult(message);
        }


        if (result is InvalidDataResult)
        {
            if (result.Result != null)
            {
                return new BadRequestObjectResult((IReadOnlyCollection<Notification>) result.Result);
            }

            return new BadRequestObjectResult(message);
        }

        if (result is Domain.Contracts.Results.NotFoundResult)
        {
            return new NotFoundObjectResult(message);
        }

        if (result is Domain.Contracts.Results.UnauthorizedResult)
        {
            return new UnauthorizedObjectResult(message);
        }

        return new Microsoft.AspNetCore.Mvc.NotFoundResult();
    }
}
