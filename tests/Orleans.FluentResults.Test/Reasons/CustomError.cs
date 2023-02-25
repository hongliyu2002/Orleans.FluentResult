namespace Orleans.FluentResults.Test.Reasons;

public class CustomError : Error
{
    public CustomError() : base("Custom message")
    {
    }

    public CustomError(string message) : base(message)
    {
    }
}
