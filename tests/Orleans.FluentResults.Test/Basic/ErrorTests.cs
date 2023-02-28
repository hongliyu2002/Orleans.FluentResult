using System.Collections.Immutable;
using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class ErrorTests
{
    [Fact]
    public void CreateError_EmptyError()
    {
        var error = new Error("");
        error.Reasons.Should().BeEmpty();
        error.Metadata.Keys.Should().BeEmpty();
    }

    [Fact]
    public void CreateErrorCausedByErrorObject_ErrorWithReason()
    {
        var error = new Error("").CausedBy(new Error("First error message"));
        error.Reasons.Should().HaveCount(1);
        error.Reasons.First().Message.Should().Be("First error message");
    }

    [Fact]
    public void CreateErrorCausedBy2ErrorObjects_ErrorWithReason()
    {
        var error = new Error("").CausedBy(new Error("First error message")).CausedBy(new Error("Second error message"));
        error.Reasons.Should().HaveCount(2);
        error.Reasons[0].Message.Should().Be("First error message");
        error.Reasons[1].Message.Should().Be("Second error message");
    }

    [Fact]
    public void CreateErrorCausedByErrorMessage_ErrorWithReason()
    {
        // Act
        var error = new Error("").CausedBy("First error message");
        error.Reasons.Should().HaveCount(1);
        error.Reasons.First().Message.Should().Be("First error message");
    }

    [Fact]
    public void CreateErrorCausedByException_ErrorWithReason()
    {
        var error = new Error("").CausedBy(new InvalidOperationException("Invalid Operation Exception"));
        error.Reasons.Should().HaveCount(1);
        error.Reasons.First().Should().BeOfType<ExceptionalError>();
        error.Reasons.First().Message.Should().Be("Invalid Operation Exception");
    }

    [Fact]
    public void CreateErrorCausedByMessageAndException_ErrorWithReason()
    {
        var error = new Error("").CausedBy("First error", new InvalidOperationException("Invalid Operation Exception"));
        error.Reasons.Should().HaveCount(1);
        error.Reasons.First().Should().BeOfType<ExceptionalError>();
        error.Reasons.First().Message.Should().Be("First error");
    }

    [Fact]
    public void CreateErrorWithMetadata_ErrorWithMetadata()
    {
        var error = new Error("").WithMetadata("Field", "CustomerName");
        error.Metadata.Should().HaveCount(1);
        error.Metadata.Keys.First().Should().Be("Field");
        error.Metadata.Values.First().Should().Be("CustomerName");
    }

    [Fact]
    public void CreateErrorWithMultipleMetadata_ErrorWithMultipleMetadata()
    {
        var error = new Error("").WithMetadata("Field", "CustomerName").WithMetadata("ErrorCode", "1.1");
        error.Metadata.Should().HaveCount(2);
        error.Metadata.Keys.Should().Contain("Field");
        error.Metadata.Keys.Should().Contain("ErrorCode");
    }

    [Fact]
    public void CreateCustomErrorWithNoMessage_CustomErrorWithMessage()
    {
        var error = new CustomError();
        error.Message.Should().BeEmpty();
        error.Reasons.Should().BeEmpty();
        error.Metadata.Keys.Should().BeEmpty();
    }

    [Fact]
    public void CreateError_FromErrorImplicitConversion()
    {
        var error = new Error("").CausedBy("First error message");
        Result result = error;
        result.IsFailed.Should().Be(true);
        result.Reasons.Should().HaveCount(1);
        error.Reasons.First().Message.Should().Be("First error message");
    }

    [Fact]
    public void CreateErrors_FromListOfErrorsImplicitConversion()
    {
        var errors = new List<Error>
                     {
                         new("First error message"),
                         new("Second error message")
                     };
        Result result = errors;
        result.IsFailed.Should().Be(true);
        result.Reasons.Should().HaveCount(2);
        result.Reasons[0].Message.Should().Be("First error message");
        result.Reasons[1].Message.Should().Be("Second error message");
    }

    [Fact]
    public void CreateErrorOfT_FromErrorImplicitConversion()
    {
        var error = new Error("").CausedBy("First error message");
        Result<string> result = error;
        result.IsFailed.Should().Be(true);
        result.Reasons.Should().HaveCount(1);
        error.Reasons.First().Message.Should().Be("First error message");
    }

    [Fact]
    public void CreateErrorOfT_FromListOfErrorsImplicitConversion()
    {
        var errors = new List<Error>
                     {
                         new("First error message"),
                         new("Second error message")
                     };
        Result<string> result = errors;
        result.IsFailed.Should().Be(true);
        result.Reasons.Should().HaveCount(2);
        result.Reasons[0].Message.Should().Be("First error message");
        result.Reasons[1].Message.Should().Be("Second error message");
    }

    #region Custom

    private record CustomError(string Message, IImmutableDictionary<string, object> Metadata, IImmutableList<IError> Reasons) : Error(Message, Metadata, Reasons)
    {
        public CustomError()
            : this(string.Empty, ImmutableDictionary<string, object>.Empty, ImmutableList<IError>.Empty)
        {
        }
    }

    #endregion

}
