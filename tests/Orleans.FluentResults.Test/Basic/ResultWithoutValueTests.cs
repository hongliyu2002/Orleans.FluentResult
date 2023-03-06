using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class ResultWithoutValueTests
{
    [Fact]
    public void CreateOkResult_SuccessResult()
    {
        var okResult = Result.Ok();
        okResult.IsFailed.Should().BeFalse();
        okResult.IsSuccess.Should().BeTrue();
        okResult.Reasons.Should().BeEmpty();
        okResult.Errors.Should().BeEmpty();
        okResult.Successes.Should().BeEmpty();
    }

    [Fact]
    public void CreateOkResultWithSuccess_SuccessResultWithSuccess()
    {
        var okResult = Result.Ok().WithSuccess("First success message");
        okResult.Reasons.Should().HaveCount(1);
        okResult.Reasons.First().Should().BeOfType<Success>();
        okResult.Reasons.First().Message.Should().Be("First success message");
        okResult.Successes.Should().HaveCount(1);
        okResult.Successes.First().Should().BeOfType<Success>();
        okResult.Successes.First().Message.Should().Be("First success message");
        okResult.Errors.Should().BeEmpty();
    }

    [Fact]
    public void CreateOkResultWith2Successes_SuccessResultWith2Successes()
    {
        var okResult = Result.Ok().WithSuccess("First success message").WithSuccess("Second success message");
        okResult.Reasons.Should().HaveCount(2);
        okResult.Reasons[0].Should().BeOfType<Success>();
        okResult.Reasons[1].Should().BeOfType<Success>();
        okResult.Reasons[0].Message.Should().Be("First success message");
        okResult.Reasons[1].Message.Should().Be("Second success message");
        okResult.Errors.Should().BeEmpty();
    }

    [Fact]
    public void CreateFailedResult_FailedResult()
    {
        var result = Result.Fail("First error message");
        result.Reasons.Should().HaveCount(1);
        result.Reasons[0].Should().BeOfType<Error>();
        result.Reasons[0].Message.Should().Be("First error message");
    }

    [Fact]
    public void CreateFailedResultWith2Errors_FailedResultWith2Errors()
    {
        var result = Result.Fail("First error message").WithError("Second error message");
        result.Reasons.Should().HaveCount(2);
        result.Reasons[0].Should().BeOfType<Error>();
        result.Reasons[1].Should().BeOfType<Error>();
        result.Reasons[0].Message.Should().Be("First error message");
        result.Reasons[1].Message.Should().Be("Second error message");
    }

    [Fact]
    public void ToResult_ReturnFailedResult()
    {
        var result = Result.Fail("First error message");
        var valueResult = result.ToResult<int>();
        valueResult.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void CreateFailedResultWithListOfErrors_FailedResultWithErrors()
    {
        var errors = new List<string>
                     {
                         "First error message",
                         "Second error message"
                     };
        var result = Result.Fail(errors);
        result.Reasons.Should().HaveCount(2);
        result.Reasons[0].Should().BeOfType<Error>();
        result.Reasons[1].Should().BeOfType<Error>();
        result.Reasons[0].Message.Should().Be("First error message");
        result.Reasons[1].Message.Should().Be("Second error message");
    }

    [Fact]
    public void Fail_WithNullEnumerableOfErrorMessages_ShouldThrow()
    {
        Action act = () => Result.Fail((IEnumerable<string>)null);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Fail_WithValidErrors_ShouldReturnFailedResult()
    {
        var errors = new List<Error>
                     {
                         new("First error message"),
                         new("Second error message")
                     };
        var result = Result.Fail(errors);
        result.IsFailed.Should().BeTrue();
        result.Reasons.Should().HaveCount(2);
        result.Reasons[0].Should().BeOfType<Error>();
        result.Reasons[1].Should().BeOfType<Error>();
        result.Reasons[0].Message.Should().Be("First error message");
        result.Reasons[1].Message.Should().Be("Second error message");
    }

    [Fact]
    public void Fail_WithNullEnumerableOfErrors_ShouldThrow()
    {
        Action act = () => Result.Fail((IEnumerable<IError>)null);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToResult_WithOkResultAndValue_ReturnSuccessResult()
    {
        var valueResult = Result.Ok();
        var result = valueResult.ToResult(2.5f);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(2.5f);
    }

    [Fact]
    public void ToResult_WithOkResultWithoutValue_ReturnSuccessResult()
    {
        var valueResult = Result.Ok();
        var result = valueResult.ToResult<bool>();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(default);
    }

    [Fact]
    public void ImplicitCastOperator_ReturnFailedValueResult()
    {
        var result = Result.Fail("First error message");
        var valueResult = result.ToResult<bool>();
        valueResult.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void FailIf_FailedConditionIsTrueAndWithStringErrorMessage_CreateFailedResult()
    {
        var result = Result.FailIf(true, "Error message");
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be("Error message");
    }

    [Fact]
    public void FailIf_FailedConditionIsTrueAndWithObjectErrorMessage_CreateFailedResult()
    {
        var result = Result.FailIf(true, new Error("Error message"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be("Error message");
    }

    [Fact]
    public void FailIf_FailedConditionIsFalseAndWithStringErrorMessage_CreateFailedResult()
    {
        var result = Result.FailIf(false, "Error message");
        result.IsFailed.Should().BeFalse();
    }

    [Fact]
    public void FailIf_FailedConditionIsFalseAndWithObjectErrorMessage_CreateFailedResult()
    {
        var result = Result.FailIf(false, new Error("Error message"));
        result.IsFailed.Should().BeFalse();
    }

    [Fact]
    public void FailIf_FailedConditionIsFalseAndWithObjectErrorFactory_CreateSuccessResult()
    {
        var result = Result.FailIf(false, LazyError());
        result.IsFailed.Should().BeFalse();
        static Error LazyError() => new ExceptionalError(new Exception("This should not be thrown!"));
    }

    [Fact]
    public void FailIf_FailedConditionIsFalseAndWithStringErrorMessageFactory_CreateSuccessResult()
    {
        var result = Result.FailIf(false, LazyError());
        result.IsFailed.Should().BeFalse();
        static string LazyError() => "This should not be thrown!";
    }

    [Fact]
    public void FailIf_FailedConditionIsTrueAndWithObjectErrorFactory_CreateFailedResult()
    {
        var result = Result.FailIf(true, "Error message");
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be("Error message");
    }

    [Fact]
    public void FailIf_FailedConditionIsTrueAndWithStringErrorMessageFactory_CreateFailedResult()
    {
        var result = Result.FailIf(true, new Error("Error message"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be("Error message");
    }

    [Fact]
    public void OkIf_SuccessConditionIsTrueAndWithStringErrorMessage_CreateFailedResult()
    {
        var result = Result.OkIf(true, "Error message");
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void OkIf_SuccessConditionIsTrueAndWithObjectErrorMessage_CreateFailedResult()
    {
        var result = Result.OkIf(true, new Error("Error message"));
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void OkIf_SuccessConditionIsTrueAndWithStringErrorMessageFactory_CreateSuccessResult()
    {
        var result = Result.OkIf(true, LazyError());
        result.IsSuccess.Should().BeTrue();
        static string LazyError() => "This should not be thrown!";
    }

    [Fact]
    public void OkIf_SuccessConditionIsTrueAnWithObjectErrorMessageFactory_CreateSuccessResult()
    {
        var result = Result.OkIf(true, LazyError());
        result.IsSuccess.Should().BeTrue();
        static Error LazyError() => new Error("This should not be thrown!");
    }

    [Fact]
    public void OkIf_SuccessConditionIsFalseAndWithStringErrorMessage_CreateFailedResult()
    {
        var result = Result.OkIf(false, "Error message");
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be("Error message");
    }

    [Fact]
    public void OkIf_SuccessConditionIsFalseAndWithObjectErrorMessage_CreateFailedResult()
    {
        var result = Result.OkIf(false, new Error("Error message"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be("Error message");
    }

    [Fact]
    public void OkIf_SuccessConditionIsFalseAndWithStringErrorMessageFactory_CreateFailedResult()
    {
        const string errorMessage = "Error message";
        var result = Result.OkIf(false, errorMessage);
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be(errorMessage);
    }

    [Fact]
    public void OkIf_SuccessConditionIsFalseAndWithObjectErrorMessageFactory_CreateFailedResult()
    {
        const string errorMessage = "Error message";
        var result = Result.OkIf(false, new Error(errorMessage));
        result.IsFailed.Should().BeTrue();
        result.Errors.Single().Message.Should().Be(errorMessage);
    }

    [Fact]
    public void Try_execute_successfully_action_return_success_result()
    {
        static void Action()
        {
        }
        var result = Result.Try(Action);
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Try_execute_failed_action_return_failed_result()
    {
        var exception = new Exception("ex message");
        void Action() => throw exception;
        var result = Result.Try(Action);
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        var error = (ExceptionalError)result.Errors.First();
        error.Message.Should().Be(exception.Message);
        error.Exception.Should().Be(exception);
    }

    [Fact]
    public void Try_execute_failed_action_with_custom_catchHandler_return_failed_result()
    {
        var exception = new Exception("ex message");
        void Action() => throw exception;
        var result = Result.Try(Action, _ => new Error("xy"));
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        var error = result.Errors.First();
        error.Message.Should().Be("xy");
    }

    [Fact]
    public async Task Try_execute_successfully_task_async_action_return_success_result()
    {
        static Task Action() => Task.FromResult(0);
        var result = await Result.TryAsync(Action);
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Try_execute_successfully_valuetask_async_action_return_success_result()
    {
        static ValueTask<int> Action() => new(0);
        var result = await Result.TryAsync(Action);
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Try_execute_failed_task_async_action_return_failed_result()
    {
        var exception = new Exception("ex message");
        Task Action() => throw exception;
        var result = await Result.TryAsync(Action);
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        var error = (ExceptionalError)result.Errors.First();
        error.Message.Should().Be(exception.Message);
        error.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task Try_execute_failed_valuetask_async_action_return_failed_result()
    {
        var exception = new Exception("ex message");
        ValueTask Action() => throw exception;
        var result = await Result.TryAsync(Action);
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        var error = (ExceptionalError)result.Errors.First();
        error.Message.Should().Be(exception.Message);
        error.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task Try_execute_failed_task_async_action_with_custom_catchHandler_return_failed_result()
    {
        var exception = new Exception("ex message");
        Task Action() => throw exception;
        var result = await Result.TryAsync(Action, true, _ => new Error("xy"));
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        var error = result.Errors.First();
        error.Message.Should().Be("xy");
    }

    [Fact]
    public async Task Try_execute_failed_valuetask_async_action_with_custom_catchHandler_return_failed_result()
    {
        var exception = new Exception("ex message");
        ValueTask Action() => throw exception;
        var result = await Result.TryAsync(Action, true, _ => new Error("xy"));
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        var error = result.Errors.First();
        error.Message.Should().Be("xy");
    }

    [Fact]
    public void Can_deconstruct_non_generic_Ok_to_isSuccess_and_isFailed()
    {
        var (isSuccess, isFailed) = Result.Ok();
        isSuccess.Should().Be(true);
        isFailed.Should().Be(false);
    }

    [Fact]
    public void Can_deconstruct_non_generic_Fail_to_isSuccess_and_isFailed()
    {
        var (isSuccess, isFailed) = Result.Fail("fail");
        isSuccess.Should().Be(false);
        isFailed.Should().Be(true);
    }

    [Fact]
    public void Can_deconstruct_non_generic_Ok_to_isSuccess_and_isFailed_and_errors()
    {
        var (isSuccess, isFailed, errors) = Result.Ok();
        isSuccess.Should().Be(true);
        isFailed.Should().Be(false);
        errors.Should().BeEmpty();
    }

    [Fact]
    public void Can_deconstruct_non_generic_Fail_to_isSuccess_and_isFailed_and_errors()
    {
        var error = new Error("fail");
        var (isSuccess, isFailed, errors) = Result.Fail(error);
        isSuccess.Should().Be(false);
        isFailed.Should().Be(true);
        errors.Count.Should().Be(1);
        errors.FirstOrDefault().Should().Be(error);
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResult()
    {
        var valueResult = Result.Fail("First error message");
        var result = valueResult.Bind(Result.Ok);
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail("First error message");
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Ok()));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResult_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail("First error message");
        var result = await valueResult.BindAsync(() => new ValueTask<Result<int>>(Result.Ok(1)));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public void Bind_ToResultWithFailedResult_ReturnFailedResult()
    {
        var valueResult = Result.Fail("First error message");
        var result = valueResult.Bind(Result.Ok);
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResult_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail("First error message");
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Ok()));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResult_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail("First error message");
        var result = await valueResult.BindAsync(() => new ValueTask<Result>(Result.Ok()));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("First error message");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResult()
    {
        var valueResult = Result.Fail("Original error message");
        var result = valueResult.Bind(() => Result.Fail<string>("Irrelevant error"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail("Original error message");
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Fail<string>("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWithFailedResultAndFailedTransformation_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail("Original error message");
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Fail<string>("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public void Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResult()
    {
        var valueResult = Result.Fail("Original error message");
        var result = valueResult.Bind(() => Result.Fail("Irrelevant error"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResultTask()
    {
        var valueResult = Result.Fail("Original error message");
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public async Task Bind_ToResultWithFailedResultAndFailedTransformation_ReturnFailedResultValueTask()
    {
        var valueResult = Result.Fail("Original error message");
        var result = await valueResult.BindAsync(() => new ValueTask<Result>(Result.Fail("Irrelevant error")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(e => e.Message).Should().BeEquivalentTo("Original error message");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResult()
    {
        var valueResult = Result.Ok().WithSuccess("An int");
        var result = valueResult.Bind(() => "One".ToResult().WithSuccess("It is one"));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResultTask()
    {
        var valueResult = Result.Ok().WithSuccess("An int");
        var result = await valueResult.BindAsync(() => Task.FromResult("One".ToResult().WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichIsSuccessful_ReturnsSuccessResultValueTask()
    {
        var valueResult = Result.Ok().WithSuccess("An int");
        var result = await valueResult.BindAsync(() => new ValueTask<Result<string>>("One".ToResult().WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("One");
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("An int", "It is one");
    }

    [Fact]
    public void Bind_ToResultWhichIsSuccessful_ReturnsSuccessResult()
    {
        var valueResult = Result.Ok().WithSuccess("First number");
        var result = valueResult.Bind(() => Result.Ok().WithSuccess("It is one"));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public async Task Bind_ToResultWhichIsSuccessful_ReturnsSuccessResultTask()
    {
        var valueResult = Result.Ok().WithSuccess("First number");
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Ok().WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public async Task Bind_ToResultWhichIsSuccessful_ReturnsSuccessResultValueTask()
    {
        var valueResult = Result.Ok().WithSuccess("First number");
        var result = await valueResult.BindAsync(() => new ValueTask<Result>(Result.Ok().WithSuccess("It is one")));
        result.IsSuccess.Should().BeTrue();
        result.Successes.Select(s => s.Message).Should().BeEquivalentTo("First number", "It is one");
    }

    [Fact]
    public void Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResult()
    {
        var valueResult = Result.Ok();
        var result = valueResult.Bind(() => Result.Fail<string>("Only one accepted"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResultTask()
    {
        var valueResult = Result.Ok();
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Fail<string>("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToAnotherValueTypeWhichFailedTransformation_ReturnsFailedResultValueTask()
    {
        var valueResult = Result.Ok();
        var result = await valueResult.BindAsync(() => new ValueTask<Result<string>>(Result.Fail<string>("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public void Bind_ToResultWhichFailedTransformation_ReturnsFailedResult()
    {
        var valueResult = Result.Ok();
        var result = valueResult.Bind(() => Result.Fail("Only one accepted"));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToResultWhichFailedTransformation_ReturnsFailedResultTask()
    {
        var valueResult = Result.Ok();
        var result = await valueResult.BindAsync(() => Task.FromResult(Result.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }

    [Fact]
    public async Task Bind_ToResultWhichFailedTransformation_ReturnsFailedResultValueTask()
    {
        var valueResult = Result.Ok();
        var result = await valueResult.BindAsync(() => new ValueTask<Result>(Result.Fail("Only one accepted")));
        result.IsFailed.Should().BeTrue();
        result.Errors.Select(s => s.Message).Should().BeEquivalentTo("Only one accepted");
    }
}
