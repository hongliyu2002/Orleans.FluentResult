using FluentAssertions;
using Orleans.FluentResults.Test.Fixtures;
using Orleans.FluentResults.Test.Integration.Grains;
using Xunit;
using Xunit.Abstractions;

namespace Orleans.FluentResults.Test.Integration;

public class ResultTValueTests : ClusterFixture
{
    public ResultTValueTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    public ITenantGrain TenantGrain => Cluster.GrainFactory.GetGrain<ITenantGrain>("Main");

    [Fact]
    public async Task GetAllUsers_OnSuccess_ReturnValue()
    {
        var result = await TenantGrain.GetUsers();
        result.IsSuccess.Should().BeTrue();
        result.Value.Count.Should().Be(3);
    }
    
    [Fact]
    public async Task GetSingle_OnSuccess_ReturnValue()
    {
        var result = await TenantGrain.GetUser(101);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("Leo Hong");
    }
}
