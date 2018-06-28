using System;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingsOn.Domain.Dto.Results;

namespace WingsOn.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ILogger _logger;

        protected BaseController(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Main wrapper around every controller action.
        /// </summary>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [DebuggerStepThrough]
        protected IActionResult HandleResult<T>(Func<ServiceResult<T>> handler)
        {
            try
            {
                var result = handler.Invoke(); // Execute the service method.

                if (!result.IsSuccessful)
                    return StatusCode((int)result.StatusCode, result);

                return Ok(result);
            }
            catch (Exception e)
            {
                var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
                _logger.LogError($"HandleResult failed! IP: {remoteIpAddress}. Reason: {e.Message}. Stacktrace: {e.StackTrace}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}