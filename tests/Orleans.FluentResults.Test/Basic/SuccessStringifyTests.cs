using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class SuccessStringifyTests
{
    [Fact]
    public void EmptySuccessToString_OnlyType()
    {
        var success = new Success("My first success");
        success.ToString().Should().Be("Success with Message='My first success'");
    }
}
