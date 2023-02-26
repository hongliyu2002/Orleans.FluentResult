using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class BindMethodTests
{
    [Fact]
    public void Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResult()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = valueResult.Bind(Result.Ok);
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResultTask()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = await valueResult.Bind(x => Task.FromResult(Result<int>.Ok(x)));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResultValueTask()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = await valueResult.Bind(x => new ValueTask<Result<int>>(Result<int>.Ok(x)));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public void Bind_ToResultWithFailedResult_ReturnFailedResult()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = valueResult.Bind(_ => Result.Ok());
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }
}
