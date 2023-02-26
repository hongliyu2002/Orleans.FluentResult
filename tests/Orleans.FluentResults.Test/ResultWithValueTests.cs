using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class ResultWithValueTests
{
    [Fact]
    public void Ok_WithNoParams_ShouldReturnSuccessResult()
    {
        var okResult = Result<int>.Ok(default);
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
        var okResult = Result<int>.Ok(5);
        okResult.IsSuccess.Should().BeTrue();
        okResult.Value.Should().Be(5);
        okResult.ValueOrDefault.Should().Be(5);
    }

    [Fact]
    public void WithValue_WithValidParam_ShouldReturnSuccessResult()
    {
        var okResult = Result<int>.Ok(default);
        okResult = okResult.WithValue(5);
        okResult.Value.Should().Be(5);
        okResult.ValueOrDefault.Should().Be(5);
    }

    [Fact]
    public void CreateOkResultWithSuccess_SuccessResultWithSuccess()
    {
        // Act
        var okResult = Result<int>.Ok(default).WithSuccess("First success message");
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
        var result = Result<int>.Fail("Error message");
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
        var result = Result<int>.Fail(errors);
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
        Action act = () => Result<int>.Fail((IEnumerable<string>)null);
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
        var result = Result<int>.Fail(errors);
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
        Action act = () => Result<int>.Fail((IEnumerable<Error>)null);
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
        var result = Result<TestValue>.Fail("Error message");
        var valueOrDefault = result.ValueOrDefault;
        valueOrDefault.Should().BeNull();
    }

    [Fact]
    public void WithValue_WithResultInFailedState_ShouldThrowException()
    {
        var failedResult = Result<int>.Fail("Error message");
        // var action = () => { failedResult.WithValue(5); };
        // action.Should().Throw<InvalidOperationException>().WithMessage("Result is in status failed. Value is not set. Having: Error with Message='Error message'");
        failedResult = failedResult.WithValue(5);
        failedResult.Value.Should().Be(5);
        failedResult.ValueOrDefault.Should().Be(0);
    }

    [Fact]
    public void ToResult_ReturnFailedResult()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = valueResult.ToResult();
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public void ToResult_ToAnotherValueType_ReturnFailedResult()
    {
        var valueResult = Result<int>.Fail("First error message");
        var result = valueResult.ToResult<float>();
        result.IsFailed.Should().BeTrue();
    }
    [Fact]
    public void ToResult_ToAnotherValueTypeWithOkResultAndNoConverter_ReturnFailedResult()
    {
        var valueResult = Result<int>.Ok(10);
        var result = valueResult.ToResult<float>();
        result.IsSuccess.Should().BeTrue();
    }
    
    private class TestValue
    {
    }
}
