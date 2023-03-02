using Orleans.TestingHost;
using Xunit;

namespace Orleans.FluentResults.Test.Fixtures;

public class ClusterFixture : IAsyncLifetime
{
    public ClusterFixture()
    {
        Cluster = new TestClusterBuilder().AddClientBuilderConfigurator<TestClientBuilderConfigurator>().AddSiloBuilderConfigurator<TestSiloConfigurator>().Build();
    }
    // public ClusterFixture(ITestOutputHelper testOutputHelper)
    // {
    //     TestOutputHelper = testOutputHelper;
    //     Cluster = new TestClusterBuilder().AddClientBuilderConfigurator<TestClientBuilderConfigurator>()
    //                                       .AddSiloBuilderConfigurator<TestSiloConfigurator>()
    //                                       .Build();
    // }

    // public ITestOutputHelper TestOutputHelper { get; }
    public TestCluster Cluster { get; }

    /// <inheritdoc />
    public Task InitializeAsync()
    {
        return Cluster.DeployAsync();
    }

    /// <inheritdoc />
    public Task DisposeAsync()
    {
        return Cluster.DisposeAsync().AsTask();
    }
}
