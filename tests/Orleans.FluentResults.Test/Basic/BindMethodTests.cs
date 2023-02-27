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

    [Fact]
    public async Task Bind_ToResultWithFailedResult_ReturnFailedResultTask()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = await valueResult.Bind(_ => Task.FromResult(Result.Ok()));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResult_ReturnFailedResultValueTask()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = await valueResult.Bind(_ => new ValueTask<Result>(Result.Ok()));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResult()
    {
        var valueResult = Result<int>.Fail("Original error message");
        var result = valueResult.Bind(_ => Result<string>.Fail("Irrelevant error"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResultTask()
    {
        var valueResult = Result<int>.Fail("Original error message");
        var result = await valueResult.Bind(_ => Task.FromResult(Result<string>.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResultValueTask()
    {
        var valueResult = Result<int>.Fail("Original error message");
        var result = await valueResult.Bind(_ => new ValueTask<Result>(Result<string>.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public void Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResult()
    {
        var valueResult = Result<int>.Fail("Original error message");
        var result = valueResult.Bind(_ => Result.Fail("Irrelevant error"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResultTask()
    {
        var valueResult = Result<int>.Fail("Original error message");
        var result = await valueResult.Bind(_ => Task.FromResult(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResultValueTask()
    {
        var valueResult = Result<int>.Fail("Original error message");
        var result = await valueResult.Bind(_ => new ValueTask<Result>(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResult()
    {
        var valueResult = Result<int>.Ok(1).WithSuccess("An int");
        var result = valueResult.Bind(n => n == 1 ? "One".ToResult().WithSuccess("It is one") : Result<string>.Fail("Only one accepted"));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResultTask()
    {
        var valueResult = Result<int>.Ok(1).WithSuccess("An int");
        var result = await valueResult.Bind(n => Task.FromResult(n == 1 ? "One".ToResult().WithSuccess("It is one") : Result<string>.Fail("Only one accepted")));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResultValueTask()
    {
        var valueResult = Result<int>.Ok(1).WithSuccess("An int");
        var result = await valueResult.Bind(n => new ValueTask<Result<string>>(n == 1 ? "One".ToResult().WithSuccess("It is one") : Result<string>.Fail("Only one accepted")));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public void Bind_ToResultWhichIsSuccessful_ReturnsSuccessResult()
    {
        var valueResult = Result<int>.Ok(1).WithSuccess("First number");
        var result = valueResult.Bind(n => Result.OkIf(n == 1, "Irrelevant").WithSuccess("It is one"));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public async Task Bind_ToResultWhichIsSuccessful_ReturnsSuccessResultTask()
    {
        var valueResult = Result<int>.Ok(1).WithSuccess("First number");
        var result = await valueResult.Bind(n => Task.FromResult(Result.OkIf(n == 1, "Irrelevant").WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public async Task Bind_ToResultWhichIsSuccessful_ReturnsSuccessResultValueTask()
    {
        var valueResult = Result<int>.Ok(1).WithSuccess("First number");
        var result = await valueResult.Bind(n => new ValueTask<Result>(Result.OkIf(n == 1, "Irrelevant").WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResult()
    {
        var valueResult = Result<int>.Ok(5);
        var result = valueResult.Bind(n => Result<string>.Fail("Only one accepted"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResultTask()
    {
        var valueResult = Result<int>.Ok(5);
        var result = await valueResult.Bind(n => Task.FromResult(Result<string>.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResultValueTask()
    {
        var valueResult = Result<int>.Ok(5);
        var result = await valueResult.Bind(n => new ValueTask<Result<string>>(Result<string>.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public void Bind_ToResultWhichFailedTransformation_ReturnsFailedResult()
    {
        var valueResult = Result<int>.Ok(5);
        var result = valueResult.Bind(n => Result.Fail("Only one accepted"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToResultWhichFailedTransformation_ReturnsFailedResultTask()
    {
        var valueResult = Result<int>.Ok(5);
        var result = await valueResult.Bind(n => Task.FromResult(Result.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToResultWhichFailedTransformation_ReturnsFailedResultValueTask()
    {
        var valueResult = Result<int>.Ok(5);
        var result = await valueResult.Bind(n => new ValueTask<Result>(Result.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }
}
