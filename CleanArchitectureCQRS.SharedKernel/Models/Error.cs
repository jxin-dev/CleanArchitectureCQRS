namespace CleanArchitectureCQRS.SharedKernel.Models
{
    public class Error
    {
        public Error(string code, string description, ErrorStatus errorStatus)
        {
            Code = code;
            Description = description;
            StatusCode = errorStatus switch
            {
                ErrorStatus.BadRequest => 400,
                ErrorStatus.Unauthorized => 401,
                ErrorStatus.Forbidden => 403,
                ErrorStatus.NotFound => 404,
                ErrorStatus.MethodNotAllowed => 405,
                ErrorStatus.Conflict => 409,
                ErrorStatus.UnprocessableEntity => 422,
                ErrorStatus.ServerError => 500,
                ErrorStatus.BadGateway => 502,
                ErrorStatus.ServiceUnavailable => 503,
                ErrorStatus.GatewayTimeout => 504,
                _ => throw new ArgumentException("Invalid error status value provided.")
            };
        }
        public string Code { get; }
        public string Description { get; }
        public int StatusCode { get; }
    }

    public enum ErrorStatus
    {
        BadRequest = 1, // 400
        Unauthorized = 2, // 401
        Forbidden = 4, // 403
        NotFound = 8,// 404
        MethodNotAllowed = 16, // 405 
        Conflict = 32, // 409
        UnprocessableEntity = 64, //422
        ServerError = 128,// 500
        BadGateway = 256, // 502
        ServiceUnavailable = 512, // 503
        GatewayTimeout = 1024, // 504
    }


}