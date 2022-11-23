namespace Service.Exceptions;

public class HttpResponseException : Exception
{
    public HttpResponseException(int statusCode, object? value = null, Exception innerException = null) : base(value?.ToString(), innerException)
    {
        (StatusCode, Value) = (statusCode, value);
    }

    public int StatusCode { get; }

    public object? Value { get; }
}