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

    public static Error InvalidHouseNumber(string nr)
    {
        return new Error($"House number {nr} is not valid - must be digit(s) plus optionally a lowercase letter a-z");
    }

    public static Error NoUsersAtHouse(string address)
    {
        return new Error($"No users found at address {address}");
    }
}
