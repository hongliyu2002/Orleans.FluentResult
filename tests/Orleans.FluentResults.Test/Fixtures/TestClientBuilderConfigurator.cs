using Microsoft.Extensions.Configuration;
using Orleans.TestingHost;

namespace Orleans.FluentResults.Test.Fixtures;

public class TestClientBuilderConfigurator : IClientBuilderConfigurator
{

    /// <inheritdoc />
    public void Configure(IConfiguration configuration, IClientBuilder clientBuilder)
    {
        clientBuilder.AddStreaming()
                     .AddMemoryStreams("Default");
    }
}
