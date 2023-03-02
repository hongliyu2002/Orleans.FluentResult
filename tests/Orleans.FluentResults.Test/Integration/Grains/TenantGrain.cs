using Orleans.Runtime;

namespace Orleans.FluentResults.Test.Integration.Grains;

public interface ITenantGrain : IGrainWithStringKey
{
    Task<Result<string>> GetUser(int id);

    Task<Result> UpdateUser(int id, string name);
}

public class Tenant : Grain, ITenantGrain
{
    private readonly IPersistentState<Users> _users;

    /// <inheritdoc />
    public Tenant(IPersistentState<Users> users)
    {
        _users = users;
    }

    /// <inheritdoc />
    public Task<Result<string>> GetUser(int id)
    {
        var result = Result.OkIf(_users.State.Repository.TryGetValue(id, out var name) && string.IsNullOrEmpty(name), name!, Errors.UserNotFound(id));
        return Task.FromResult(result);
    }

    /// <inheritdoc />
    public async Task<Result> UpdateUser(int id, string name)
    {
        return null;
    }
}

[GenerateSerializer]
public class Users
{
    [Id(0)]
    public Dictionary<int, string> Repository { get; } = new()
                                                         {
                                                             { 100, "Boss" },
                                                             { 101, "Leo" },
                                                             { 102, "Janet" }
                                                         };
}
