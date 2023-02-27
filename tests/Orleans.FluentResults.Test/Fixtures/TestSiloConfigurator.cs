using Orleans.TestingHost;

namespace Orleans.FluentResults.Test.Fixtures;

public class TestSiloConfigurator : ISiloConfigurator
{

    /// <inheritdoc />
    public void Configure(ISiloBuilder siloBuilder)
    {
        siloBuilder.AddMemoryGrainStorageAsDefault()
                   .AddMemoryGrainStorage("PubSubStore")
                   .AddStreaming()
                   .AddMemoryStreams("Default");
    }
}
