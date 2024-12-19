using System.Net;

namespace Infrastructure;

public class Response<T>
{
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int StatusCode { get; set; }
    public Response(T data)
    {
        Data = data;
        Message = " ";
        StatusCode = 200;
    }
    public Response(HttpStatusCode statusCode,string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Data = default;
    }
}