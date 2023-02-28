using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class BindMethodTests
{
    [Fact]
    public void Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResult()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = valueResult.Bind<int>(i => Result.Ok(i + 1));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = await valueResult.BindAsync<int, int>(x => Task.FromResult(Result.Ok(x)));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = await valueResult.BindAsync<int, int>(x => new ValueTask<Result<int>>(Result.Ok(x)));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public void Bind_ToResultWithFailedResult_ReturnFailedResult()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = valueResult.Bind(_ => Result.Ok());
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResult_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = await valueResult.BindAsync(_ => Task.FromResult(Result.Ok()));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResult_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = await valueResult.BindAsync(_ => new ValueTask<Result>(Result.Ok()));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResult()
    {
        var valueResult = Result.Fail<int>("Original error message");
        var result = valueResult.Bind(_ => Result.Fail<string>("Irrelevant error"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail<int>("Original error message");
        var result = await valueResult.BindAsync(_ => Task.FromResult(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail<int>("Original error message");
        var result = await valueResult.BindAsync(_ => new ValueTask<Result>(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public void Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResult()
    {
        var valueResult = Result.Fail<int>("Original error message");
        var result = valueResult.Bind(_ => Result.Fail("Irrelevant error"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail<int>("Original error message");
        var result = await valueResult.BindAsync(_ => Task.FromResult(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail<int>("Original error message");
        var result = await valueResult.BindAsync(_ => new ValueTask<Result>(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResult()
    {
        var valueResult = Result.Ok(1).WithSuccess("An int");
        var result = valueResult.Bind(n => n == 1 ? "One".ToResult().WithSuccess("It is one") : Result.Fail<string>("Only one accepted"));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResultTask()
    {
        var valueResult = Result.Ok(1).WithSuccess("An int");
        var result = await valueResult.BindAsync(n => Task.FromResult(n == 1 ? "One".ToResult().WithSuccess("It is one") : Result.Fail<string>("Only one accepted")));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResultValueTask()
    {
        var valueResult = Result.Ok(1).WithSuccess("An int");
        var result = await valueResult.BindAsync(n => new ValueTask<Result<string>>(n == 1 ? "One".ToResult().WithSuccess("It is one") : Result.Fail<string>("Only one accepted")));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public void Bind_ToResultWhichIsSuccessful_ReturnsSuccessResult()
    {
        var valueResult = Result.Ok(1).WithSuccess("First number");
        var result = valueResult.Bind(n => Result.OkIf(n == 1, "Irrelevant").WithSuccess("It is one"));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public async Task Bind_ToResultWhichIsSuccessful_ReturnsSuccessResultTask()
    {
        var valueResult = Result.Ok(1).WithSuccess("First number");
        var result = await valueResult.BindAsync(n => Task.FromResult(Result.OkIf(n == 1, "Irrelevant").WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public async Task Bind_ToResultWhichIsSuccessful_ReturnsSuccessResultValueTask()
    {
        var valueResult = Result.Ok(1).WithSuccess("First number");
        var result = await valueResult.BindAsync(n => new ValueTask<Result>(Result.OkIf(n == 1, "Irrelevant").WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResult()
    {
        var valueResult = Result.Ok(5);
        var result = valueResult.Bind(_ => Result.Fail<string>("Only one accepted"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResultTask()
    {
        var valueResult = Result.Ok(5);
        var result = await valueResult.BindAsync(_ => Task.FromResult(Result.Fail<string>("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResultValueTask()
    {
        var valueResult = Result.Ok(5);
        var result = await valueResult.BindAsync(_ => new ValueTask<Result<string>>(Result.Fail<string>("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public void Bind_ToResultWhichFailedTransformation_ReturnsFailedResult()
    {
        var valueResult = Result.Ok(5);
        var result = valueResult.Bind(_ => Result.Fail("Only one accepted"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToResultWhichFailedTransformation_ReturnsFailedResultTask()
    {
        var valueResult = Result.Ok(5);
        var result = await valueResult.BindAsync(_ => Task.FromResult(Result.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToResultWhichFailedTransformation_ReturnsFailedResultValueTask()
    {
        var valueResult = Result.Ok(5);
        var result = await valueResult.BindAsync(_ => new ValueTask<Result>(Result.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }
}
