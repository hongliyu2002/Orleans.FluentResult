using FluentAssertions;
using Orleans.FluentResults.Test.Fixtures;
using Orleans.FluentResults.Test.Integration.Grains;
using Orleans.TestingHost;
using Xunit;
using Xunit.Abstractions;

namespace Orleans.FluentResults.Test.Integration;

[Collection(TestCollectionFixture.Name)]
public class ResultTValueTests
{
    private readonly TestCluster _cluster;
    private readonly ITestOutputHelper _testOutputHelper;

    public ResultTValueTests(ClusterFixture fixture, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _cluster = fixture.Cluster;
    }

    public ITenantGrain TenantGrain => _cluster.GrainFactory.GetGrain<ITenantGrain>("Main");

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

    [Fact]
    public async Task GetError_OnFailureWithSingleError_ReturnsSingleError()
    {
        var result = await TenantGrain.GetUser(999);
        result.IsSuccess.Should().BeFalse();
        result.Errors.First().Should().Be(Errors.UserNotFound(999));
    }

    [Fact]
    public async Task GetErrors_OnFailureWithMultipleErrors_ReturnsErrors()
    {
        var result = await TenantGrain.GetUsersAtAddress("200233A", "1aa");
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should()
              .HaveCount(3)
              .And.Contain(error => (Error)error == Errors.InvalidPostalCode("200233A"))
              .And.Contain(error => (Error)error == Errors.InvalidHouseNumber("1aa"));
        foreach (var resultError in result.Errors)
        {
            _testOutputHelper.WriteLine(resultError.ToString());
        }
    }
}
