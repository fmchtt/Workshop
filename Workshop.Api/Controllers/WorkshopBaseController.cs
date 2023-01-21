using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.DTO.Output.Generic;
using Workshop.Domain.Contracts.Results;

namespace Workshop.Api.Controllers;

using NotificationList = IReadOnlyCollection<Notification>;

public abstract class WorkshopBaseController : ControllerBase
{
    [NonAction]
    public dynamic ParseResult(GenericResult result)
    {
        var message = result.Message;

        if (result is SuccessResult)
        {
            if (result.Result != null)
            {
                return Ok(result.Result);
            }

            return Ok(message);
        }

        if (result is InvalidDataResult)
        {
            if (result.Result != null)
            {
                return BadRequest((NotificationList) result.Result);
            }

            return BadRequest(message);
        }

        if (result is Domain.Contracts.Results.NotFoundResult)
        {
            return NotFound(message);
        }

        if (result is Domain.Contracts.Results.UnauthorizedResult)
        {
            return Unauthorized(message);
        }

        return InternalServerError("Erro ao converter o resultado da operação");
    }

    [NonAction]
    public Guid GetUserId()
    {
        var userId = User?.Identity?.Name;
        if (userId == null)
        {
            return Guid.Empty;
        }

        return Guid.Parse(userId);
    }

    [NonAction]
    public T Ok<T>(T data)
    {
        Response.StatusCode = 200;

        return data;
    }

    [NonAction]
    public MessageResult Ok(string message)
    {
        Response.StatusCode = 200;

        return new MessageResult(message);
    }

    [NonAction]
    public T NotFound<T>(T data)
    {
        Response.StatusCode = 404;

        return data;
    }

    [NonAction]
    public MessageResult NotFound(string message)
    {
        Response.StatusCode = 404;

        return new MessageResult(message);
    }

    [NonAction]
    public T Unauthorized<T>(T data)
    {
        Response.StatusCode = 401;

        return data;
    }

    [NonAction]
    public MessageResult Unauthorized(string message)
    {
        Response.StatusCode = 401;

        return new MessageResult(message);
    }

    [NonAction]
    public T BadRequest<T>(T data)
    {
        Response.StatusCode = 400;

        return data;
    }

    [NonAction]
    public MessageResult BadRequest(string message)
    {
        Response.StatusCode = 400;

        return new MessageResult(message);
    }

    [NonAction]
    public MessageResult InternalServerError(string message)
    {
        Response.StatusCode = 500;

        return new MessageResult(message);
    }
}
