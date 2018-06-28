using System.Net;

namespace WingsOn.Domain.Dto.Results
{
    public class ServiceResult<TPayload>
    {
        public bool IsSuccessful { get; set; }

        public TPayload Payload { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
    }
}