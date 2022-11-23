namespace Service.Exceptions;

public class APIException : HttpResponseException
{
    public APIException(int statusCode, object? value = null, Exception innerException = null) : base(statusCode, value, innerException) { }
}