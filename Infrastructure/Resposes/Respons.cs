using System.Net;

namespace Infrastructure.Resposes;

public class Respons<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; }

    public Respons(T date)
    {
        StatusCode = 200;
        Data = date;
        Message = "Success";
    }

    public Respons(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Data = default;
    }
}