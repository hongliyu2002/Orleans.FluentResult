using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;

namespace Orleans.FluentResults.Test.Integration.Grains;

public interface ITenantGrain : IGrainWithStringKey
{
    Task<Result<Dictionary<int, string>>> GetUsers();

    Task<Result<ImmutableArray<int>>> GetUsersAtAddress(string postalCode, string nr);

    Task<Result<string>> GetUser(int id);

    Task<Result> UpdateUser(int id, string name);
}

public partial class TenantGrain : Grain, ITenantGrain
{
    private readonly ILogger<TenantGrain> _logger;
    private readonly IPersistentState<Users> _users;

    /// <inheritdoc />
    public TenantGrain([PersistentState("Tenant", "MemoryStore")] IPersistentState<Users> users, ILogger<TenantGrain> logger)
    {
        _users = users;
        _logger = logger;
    }

    public Task<Result<Dictionary<int, string>>> GetUsers()
    {
        var result = Result.Ok(_users.State.Repository);
        return Task.FromResult(result);
    }

    /// <inheritdoc />
    public Task<Result<ImmutableArray<int>>> GetUsersAtAddress(string postalCode, string nr)
    {
        var result = Result.Ok()
                           .Verify(r => !string.IsNullOrEmpty(postalCode) && PostalCodeRegex()
                                           .IsMatch(postalCode), Errors.InvalidPostalCode(postalCode))
                           .Verify(r => !string.IsNullOrEmpty(nr) && HouseNrRegex()
                                           .IsMatch(nr), Errors.InvalidHouseNumber(nr))
                           .TapTry(() => Console.WriteLine("Fuck"))
                           .Verify(r => int.TryParse(nr, out var number) && number % 2 == 1, Errors.NoUsersAtHouse($"{postalCode} {nr}"))
                           .Map(() => ImmutableArray.Create(0));
        return Task.FromResult(result);
    }

    /// <inheritdoc />
    public Task<Result<string>> GetUser(int id)
    {
        var result = Result.OkIf(_users.State.Repository.TryGetValue(id, out var name) && !string.IsNullOrEmpty(name), name!, Errors.UserNotFound(id));
        return Task.FromResult(result);
    }

    /// <inheritdoc />
    public Task<Result> UpdateUser(int id, string name)
    {
        var result = Result.OkIf(_users.State.Repository.ContainsKey(id), Errors.UserNotFound(id))
                           .TapTry(() => _users.State.Repository[id] = name);
        return Task.FromResult(result);
    }

    [GeneratedRegex("^\\d{6}$")]
    private static partial Regex PostalCodeRegex();

    [GeneratedRegex("^\\d+[a-z]?$")]
    private static partial Regex HouseNrRegex();
}

[GenerateSerializer]
public class Users
{
    [Id(0)]
    public Dictionary<int, string> Repository { get; } = new()
                                                         {
                                                             { 100, "Boss Hong" },
                                                             { 101, "Leo Hong" },
                                                             { 102, "Janet Lai" }
                                                         };
}
