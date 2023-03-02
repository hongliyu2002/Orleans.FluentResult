using Microsoft.Extensions.Logging;
using Orleans.Runtime;

namespace Orleans.FluentResults.Test.Integration.Grains;

public interface ITenantGrain : IGrainWithStringKey
{
    Task<Result<Dictionary<int, string>>> GetUsers();
    
    Task<Result<string>> GetUser(int id);

    Task<Result> UpdateUser(int id, string name);
}

public class TenantGrain : Grain, ITenantGrain
{
    private readonly IPersistentState<Users> _users;
    private readonly ILogger<TenantGrain> _logger;

    /// <inheritdoc />
    public TenantGrain(
        [PersistentState("Tenant", "MemoryStore")]
        IPersistentState<Users> users, ILogger<TenantGrain> logger)
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
    public Task<Result<string>> GetUser(int id)
    {
        var result = Result.OkIf(_users.State.Repository.TryGetValue(id, out var name) && !string.IsNullOrEmpty(name), name!, Errors.UserNotFound(id));
        return Task.FromResult(result);
    }

    /// <inheritdoc />
    public Task<Result> UpdateUser(int id, string name)
    {
        var result = Result.OkIf(_users.State.Repository.ContainsKey(id), Errors.UserNotFound(id));
        result = result.TapTry(() => _users.State.Repository[id] = name);
        return Task.FromResult(result);
    }
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
