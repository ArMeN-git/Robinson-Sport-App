using System.Net;

namespace RobinsonSportApp.Core.CustomExceptions;

public class RBException : Exception
{
    public int Code { get; }
    
    public RBException(string message, HttpStatusCode statusCode) : base(message)
    {
        Code = (int)statusCode;
    }
}
