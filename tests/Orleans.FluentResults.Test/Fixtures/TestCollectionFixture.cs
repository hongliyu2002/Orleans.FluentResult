using Xunit;

namespace Orleans.FluentResults.Test.Fixtures;

[CollectionDefinition(Name)]
public class TestCollectionFixture : ICollectionFixture<ClusterFixture>
{
    public const string Name = "ClusterCollection";
}
