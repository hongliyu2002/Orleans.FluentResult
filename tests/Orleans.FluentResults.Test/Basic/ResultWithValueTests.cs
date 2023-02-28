using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class ResultWithValueTests
{
    [Fact]
    public void Ok_WithNoParams_ShouldReturnSuccessResult()
    {
        var okResult = Result.Ok(0);
        okResult.IsFailed.Should().BeFalse();
        okResult.IsSuccess.Should().BeTrue();
        okResult.Reasons.Should().BeEmpty();
        okResult.Errors.Should().BeEmpty();
        okResult.Successes.Should().BeEmpty();
        okResult.Value.Should().Be(0);
        okResult.ValueOrDefault.Should().Be(0);
    }

    [Fact]
    public void Ok_WithValidValue_ShouldReturnSuccessResult()
    {
        var okResult = Result.Ok(5);
        okResult.IsSuccess.Should().BeTrue();
        okResult.Value.Should().Be(5);
        okResult.ValueOrDefault.Should().Be(5);
    }

    [Fact]
    public void WithValue_WithValidParam_ShouldReturnSuccessResult()
    {
        var okResult = Result.Ok<int>();
        okResult = okResult.WithValue(5);
        okResult.Value.Should().Be(5);
        okResult.ValueOrDefault.Should().Be(5);
    }

    [Fact]
    public void CreateOkResultWithSuccess_SuccessResultWithSuccess()
    {
        // Act
        var okResult = Result.Ok(0).WithSuccess("First success message");
        okResult.Reasons.Should().HaveCount(1);
        okResult.Reasons.First().Should().BeOfType<Success>();
        okResult.Reasons.First().Message.Should().Be("First success message");
        okResult.Successes.Should().HaveCount(1);
        okResult.Successes.First().Should().BeOfType<Success>();
        okResult.Successes.First().Message.Should().Be("First success message");
        okResult.Errors.Should().BeEmpty();
    }

    [Fact]
    public void Fail_WithValidErrorMessage_ShouldReturnFailedResult()
    {
        var result = Result.Fail<int>("Error message");
        result.IsFailed.Should().BeTrue();
        result.ValueOrDefault.Should().Be(0);
    }

    [Fact]
    public void Fail_WithValidErrorMessages_ShouldReturnFailedResult()
    {
        var errors = new List<string>
                     {
                         "First error message",
                         "Second error message"
                     };
        var result = Result.Fail<int>(errors);
        result.IsFailed.Should().BeTrue();
        result.Reasons.Should().HaveCount(2);
        result.Reasons[0].Should().BeOfType<Error>();
        result.Reasons[1].Should().BeOfType<Error>();
        result.Reasons[0].Message.Should().Be("First error message");
        result.Reasons[1].Message.Should().Be("Second error message");
        result.ValueOrDefault.Should().Be(0);
    }

    [Fact]
    public void Fail_WithNullEnumerableOfErrorMessages_ShouldThrow()
    {
        Action act = () => Result.Fail<int>((IEnumerable<string>)null);
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
        var result = Result.Fail<int>(errors);
        result.IsFailed.Should().BeTrue();
        result.Reasons.Should().HaveCount(2);
        result.Reasons[0].Should().BeOfType<Error>();
        result.Reasons[1].Should().BeOfType<Error>();
        result.Reasons[0].Message.Should().Be("First error message");
        result.Reasons[1].Message.Should().Be("Second error message");
        result.ValueOrDefault.Should().Be(0);
    }

    [Fact]
    public void Fail_WithNullEnumerableOfErrors_ShouldThrow()
    {
        Action act = () => Result.Fail<int>((IEnumerable<IError>)null);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ValueOrDefault_WithDateTime_ShouldReturnFailedResult()
    {
        var result = Result<DateTime>.Fail("Error message");
        var valueOrDefault = result.ValueOrDefault;
        var defaultDateTime = default(DateTime);
        valueOrDefault.Should().Be(defaultDateTime);
    }

    [Fact]
    public void ValueOrDefault_WithObject_ShouldReturnFailedResult()
    {
        var result = Result<TestClass>.Fail("Error message");
        var valueOrDefault = result.ValueOrDefault;
        valueOrDefault.Should().BeNull();
    }

    [Fact]
    public void WithValue_WithResultInFailedState_ShouldThrowException()
    {
        var failedResult = Result.Fail<int>("Error message");
        // var action = () => { failedResult.WithValue(5); };
        // action.Should().Throw<InvalidOperationException>().WithMessage("Result is in status failed. Value is not set. Having: Error with Message='Error message'");
        failedResult = failedResult.WithValue(5);
        failedResult.Value.Should().Be(5);
        failedResult.ValueOrDefault.Should().Be(0);
    }

    [Fact]
    public void ToResult_ReturnFailedResult()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = valueResult.ToResult();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void ToResult_ToAnotherValueType_ReturnFailedResult()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = valueResult.ToResult<int, float>();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void ToResult_ToAnotherValueTypeWithOkResultAndNoConverter_ReturnFailedResult()
    {
        var valueResult = Result.Ok(4);
        var result = valueResult.ToResult<int, float>();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(4);
    }

    [Fact]
    public void ToResult_ToAnotherValueTypeWithOkResultAndConverter_ReturnSuccessResult()
    {
        var valueResult = Result.Ok(4);
        var result = valueResult.Map<int, float>(v => v + 1);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(5);
    }

    [Fact]
    public void ImplicitCastOperator_ReturnFailedResult()
    {
        var valueResult = Result.Fail<int>("First error message");
        var result = valueResult.ToResult();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void Try_execute_successfully_action_return_success_result()
    {
        static int Action() => 5;
        var result = Result<int>.Try(Action);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(5);
    }

    [Fact]
    public void Try_execute_failed_action_return_failed_result()
    {
        var exception = new Exception("ex message");
        int Action() => throw exception;
        var result = Result<int>.Try(Action);
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
        int Action() => throw exception;
        var result = Result<int>.Try(Action, _ => new Error("xy"));
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        var error = result.Errors.First();
        error.Message.Should().Be("xy");
    }

    [Fact]
    public async Task Try_execute_successfully_task_async_action_return_success_result()
    {
        static Task<int> Action() => Task.FromResult(5);
        var result = await Result.TryAsync(Action);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(5);
    }

    [Fact]
    public async Task Try_execute_successfully_valuetask_async_action_return_success_result()
    {
        static ValueTask<int> Action() => new(5);
        var result = await Result.TryAsync(Action);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(5);
    }

    [Fact]
    public async Task Try_execute_failed_task_async_action_return_failed_result()
    {
        var exception = new Exception("ex message");
        Task<int> Action() => throw exception;
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
        ValueTask<int> Action() => throw exception;
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
        Task<int> Action() => throw exception;
        var result = await Result.TryAsync(Action, _ => new Error("xy"));
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        var error = result.Errors.First();
        error.Message.Should().Be("xy");
    }

    [Fact]
    public async Task Try_execute_failed_valuetask_async_action_with_custom_catchHandler_return_failed_result()
    {
        var exception = new Exception("ex message");
        ValueTask<int> Action() => throw exception;
        var result = await Result.TryAsync(Action, _ => new Error("xy"));
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        var error = result.Errors.First();
        error.Message.Should().Be("xy");
    }

    [Fact]
    public void Implicit_conversion_T_is_converted_to_Success_result_of_T()
    {
        var value = "result";
        Result<string> result = value;
        result.IsSuccess.Should().BeTrue();
        result.IsFailed.Should().BeFalse();
        result.Reasons.Should().BeEmpty();
        result.Errors.Should().BeEmpty();
        result.Value.Should().Be(value);
        result.Value.Should().BeOfType<string>();
        result.ValueOrDefault.Should().Be(value);
        result.ValueOrDefault.Should().BeOfType<string>();
    }

    [Fact]
    public void Implicit_conversion_Null_is_converted_to_Success_result_of_Null()
    {
        Result<object> result = (object)null;
        result.IsSuccess.Should().BeTrue();
        result.IsFailed.Should().BeFalse();
        result.Reasons.Should().BeEmpty();
        result.Errors.Should().BeEmpty();
        result.Value.Should().BeNull();
        result.ValueOrDefault.Should().BeNull();
    }

    [Fact]
    public void Implicit_conversion_Result_Value_is_converted_to_Result_object()
    {
        Result<object> result = new Result<int>().WithValue(42);
        result.IsSuccess.Should().BeTrue();
        result.IsFailed.Should().BeFalse();
        result.Reasons.Should().BeEmpty();
        result.Errors.Should().BeEmpty();
        result.Value.Should().NotBeNull();
        result.ValueOrDefault.Should().NotBeNull();
        result.Value.Should().Be(42);
    }

    [Fact]
    public void Implicit_conversion_Result_Value_is_converted_to_Result_object_with_Reasons()
    {
        var intResult = new Result<int>().WithValue(42).WithReason(new CustomSuccess());
        Result<object> result = intResult;
        result.IsSuccess.Should().BeTrue();
        result.IsFailed.Should().BeFalse();
        result.Errors.Should().BeEmpty();
        result.Value.Should().NotBeNull();
        result.ValueOrDefault.Should().NotBeNull();
        result.Value.Should().Be(42);
        result.Reasons.Should().ContainSingle();
        result.Reasons.Should().AllBeEquivalentTo(new CustomSuccess());
    }

    [Fact]
    public void Implicit_conversion_Result_Value_is_converted_to_Result_object_with_Errors()
    {
        Result<object> result = new Result<int>().WithValue(42).WithError("foo");
        result.IsSuccess.Should().BeFalse();
        result.IsFailed.Should().BeTrue();
        result.Reasons.Should().ContainSingle();
        result.Reasons.Should().AllBeEquivalentTo(new Error("foo"));
        result.Errors.Should().ContainSingle();
        result.Errors.Should().AllBeEquivalentTo(new Error("foo"));
    }

    [Fact]
    public void Can_deconstruct_generic_Ok_to_isSuccess_and_isFailed()
    {
        var (isSuccess, isFailed, _) = Result<bool>.Ok(true);
        isSuccess.Should().Be(true);
        isFailed.Should().Be(false);
    }

    [Fact]
    public void Can_deconstruct_generic_Fail_to_isSuccess_and_isFailed()
    {
        var (isSuccess, isFailed, _) = Result<bool>.Fail("fail");
        isSuccess.Should().Be(false);
        isFailed.Should().Be(true);
    }

    [Fact]
    public void Can_deconstruct_generic_Ok_to_isSuccess_and_isFailed_and_value()
    {
        var (isSuccess, isFailed, valueOrDefault) = Result.Ok(100);
        isSuccess.Should().Be(true);
        isFailed.Should().Be(false);
        valueOrDefault.Should().Be(100);
    }

    [Fact]
    public void Can_deconstruct_generic_Fail_to_isSuccess_and_isFailed_and_value()
    {
        var (isSuccess, isFailed, valueOrDefault) = Result.Fail<int>("fail");
        isSuccess.Should().Be(false);
        isFailed.Should().Be(true);
        valueOrDefault.Should().Be(default);
    }

    [Fact]
    public void Can_deconstruct_generic_Ok_to_isSuccess_and_isFailed_and_value_with_errors()
    {
        var (isSuccess, isFailed, valueOrDefault, errors) = Result.Ok(100);
        isSuccess.Should().Be(true);
        isFailed.Should().Be(false);
        valueOrDefault.Should().Be(100);
        errors.Should().BeEmpty();
    }

    [Fact]
    public void Can_deconstruct_generic_Fail_to_isSuccess_and_isFailed_and_errors_with_value()
    {
        var error = new Error("fail");
        var (isSuccess, isFailed, valueOrDefault, errors) = Result<bool>.Fail(error);
        isSuccess.Should().Be(false);
        isFailed.Should().Be(true);
        valueOrDefault.Should().Be(default);
        errors.Count.Should().Be(1);
        errors.FirstOrDefault().Should().Be(error);
    }

    [Fact]
    public void Dynamic_value_is_implicit_converted_to_ValueResult()
    {
        var result = DynamicConvert("100", typeof(int));
        ((object)result.Value).Should().Be(100);
        ((object)result.Value).Should().BeOfType(typeof(int));
    }

    private static Result<dynamic> DynamicConvert(dynamic source, Type dest)
    {
        var result = new Result<dynamic>();
        var convertedValue = Convert.ChangeType(source, dest);
        var dynamicResult = ResultTExtensions.WithValue(result, convertedValue);
        return dynamicResult;
    }

    #region Custom

    private class TestClass
    {
    }

    public record CustomSuccess : Success
    {
    }

    #endregion

}
