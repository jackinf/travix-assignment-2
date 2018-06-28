using System.Net;
using WingsOn.Domain.Dto.Results;

namespace WingsOn.Domain.Factories
{
    public static class ServiceResultFactory
    {
        public static ServiceResult<TPayload> Success<TPayload>(TPayload payload, string message = "")
        {
            return new ServiceResult<TPayload>
            {
                IsSuccessful = true,
                Payload = payload,
                Message = message,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static ServiceResult<TPayload> Fail<TPayload>(string errorMessage)
        {
            return new ServiceResult<TPayload>
            {
                IsSuccessful = false,
                Message = errorMessage
            };
        }
    }
}