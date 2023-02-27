using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class ResultStringifyTests
{
    [Fact]
    public void OkResultWithoutValueToString_OkResult()
    {
        var result = Result.Ok();
        result.ToString().Should().Be("Result: IsSuccess='True'");
    }

    [Fact]
    public void FailedResultWithoutValueToString_FailedResult()
    {
        var result = Result.Fail("My error");
        result.ToString().Should().Be("Result: IsSuccess='False', Reasons='Error with Message='My error''");
    }

    [Fact]
    public void OkResultWithValueToString_OkResult()
    {
        var result = Result.Ok(0);
        result.ToString().Should().Be("Result: IsSuccess='True', Value='0'");
    }

    [Fact]
    public void FailedResultWithValueToString_FailedResult()
    {
        var result = Result<int>.Fail("My error");
        result.ToString().Should().Be("Result: IsSuccess='False', Reasons='Error with Message='My error'', Value='0'");
    }
}
