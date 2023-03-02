using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test.Detail;

// [Collection(NonParallelTestCollectionDefinition.Name)]
public class CombineTests : TestBase
{
    [Fact]
    public void Combine_combines_all_errors_together()
    {
        var result1 = Result.Ok();
        var result2 = Result.Fail("Fail 1");
        var result3 = Result.Fail("Fail 2");
        var result = Result.Combine(result1, result2, result3);
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().BeEquivalentTo(result2.Errors.Union(result3.Errors));
    }

    [Fact]
    public void Combine_aggregates_identical_errors_with_count()
    {
        var result1 = Result.Ok();
        var result2 = Result.Fail("Fail 1");
        var result3 = Result.Fail("Fail 1");
        var result4 = Result.Fail("Fail 2");
        var result = Result.Combine(result1, result2, result3, result4);
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().BeEquivalentTo(result2.Errors.Union(result3.Errors).Union(result4.Errors));
    }

    [Fact]
    public void Combine_returns_Ok_if_no_failures()
    {
        var result1 = Result.Ok();
        var result2 = Result.Ok();
        Result<string> result3 = Result.Ok("Some string");
        Result result = Result.Combine(";", result1, result2, result3);
        result.IsSuccess.Should().BeTrue();
    }
}
