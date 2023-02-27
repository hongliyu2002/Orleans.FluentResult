namespace Orleans.FluentResults.Test.Integration.Grains;

public static class Errors
{
    public static Error UserNotFound(int id)
    {
        return new Error($"User {id} not found");
    }

    public static Error InvalidPostalCode(string code)
    {
        return new Error($"Postal code {code} is not valid - must be 6 digits letters");
    }
}
