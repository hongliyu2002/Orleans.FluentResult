using System.Collections.Immutable;
using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class CheckReasonsTests
{

    [Fact]
    public void HasException_WithRootError()
    {
        var error = new ExceptionalError(new CustomException(1));
        var result = Result.Fail(error);
        result.HasException<CustomException>(out var errors).Should().BeTrue();
        errors.Should().HaveCount(1).And.Contain(error);
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasExceptionWithPredicate_WithRootError()
    {
        var error = new ExceptionalError(new CustomException(1));
        var result = Result.Fail(error);
        result.HasException<CustomException>(ex => ex.Id == 1).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasExceptionInNestedError_WithRootError()
    {
        var error = new ExceptionalError(new CustomException(1));
        var result = Result.Ok().WithError(error);
        result.HasException<CustomException>().Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasExceptionWithPredicatInNestedError_WithRootError()
    {
        var error = new ExceptionalError(new CustomException(1));
        var result = Result.Ok().WithError(error);
        result.HasException<CustomException>(e => e.Id == 1).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasException_WithSearchedError()
    {
        var result = Result.Fail(new NotFoundError(3).CausedBy(new CustomException(1)));
        result.HasException<CustomException>().Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasExceptionWithPredicate_WithSearchedError()
    {
        var result = Result.Fail(new NotFoundError(3).CausedBy(new CustomException(1)));
        result.HasException<CustomException>(e => e.Id == 1).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasException_WithoutSearchedError()
    {
        var result = Result.Ok();
        result.HasException<CustomException>().Should().BeFalse();
        result.IsFailed.Should().BeFalse();
    }

    [Fact]
    public void HasExceptionInNestedError_WithoutSearchedError()
    {
        var result = Result.Ok().WithError(new Error("Main Error").CausedBy(new CustomException(1)));
        result.HasException<CustomException>().Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasExceptionInVeryDeepNestedError_WithoutSearchedError()
    {
        var result = Result.Ok()
                           .WithError(new Error("Main Error").CausedBy(new Error("Another Error").CausedBy(new Error("Root Error"))
                                                                                                 .CausedBy(new NotFoundError(2))
                                                                                                 .CausedBy(new CustomException(1))));
        result.HasException<CustomException>().Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasExceptionInVeryDeepNestedErrorWithPredicate_WithoutSearchedError()
    {
        var result = Result.Ok()
                           .WithError(new Error("Main Error").CausedBy(new Error("Another Error").CausedBy(new Error("Root Error"))
                                                                                                 .CausedBy(new NotFoundError(2))
                                                                                                 .CausedBy(new CustomException(1))));
        result.HasException<CustomException>(e => e.Id == 1).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasError_WithSearchedError()
    {
        var error = new NotFoundError(3);
        var result = Result.Fail(error);
        result.HasError<NotFoundError>(out var errors).Should().BeTrue();
        errors.Should().HaveCount(1).And.Contain(error);
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasError_WithBaseError()
    {
        var error = new NotFoundError(3);
        var result = Result.Fail(error);
        result.HasError<Error>(out var errors).Should().BeTrue();
        errors.Should().HaveCount(1).And.Contain(error);
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasErrorWithPredicate_WithSearchedError()
    {
        var result = Result.Fail(new NotFoundError(3));
        result.HasError<NotFoundError>(e => e.Id == 3).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasError_WithoutSearchedError()
    {
        var result = Result.Ok();
        result.HasError<NotFoundError>().Should().BeFalse();
        result.IsFailed.Should().BeFalse();
    }

    [Fact]
    public void HasErrorInNestedError_WithoutSearchedError()
    {
        var result = Result.Ok().WithError(new Error("Main Error").CausedBy(new NotFoundError(2)));
        result.HasError<NotFoundError>().Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasErrorInVeryDeepNestedError_WithoutSearchedError()
    {
        var result = Result.Ok()
                           .WithError(new Error("Main Error").CausedBy(new Error("Another Error").CausedBy(new Error("Root Error"))
                                                                                                 .CausedBy(new NotFoundError(2))
                                                                                                 .CausedBy(new CustomException(1))));
        result.HasError<NotFoundError>().Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasErrorInVeryDeepNestedErrorWithPredicate_WithoutSearchedError()
    {
        var result = Result.Ok()
                           .WithError(new Error("Main Error").CausedBy(new Error("Another Error").CausedBy(new Error("Root Error"))
                                                                                                 .CausedBy(new NotFoundError(2))
                                                                                                 .CausedBy(new CustomException(1))));
        result.HasError<NotFoundError>(e => e.Id == 2).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasErrorInNestedErrorWithPredicate_WithoutSearchedError()
    {
        var originalResult = Result.Fail(new NotFoundError(1));
        var result = Result.Fail(new NotFoundError(2).CausedBy(originalResult.Errors));
        result.HasError<NotFoundError>(e => e.Id == 1).Should().BeTrue();
        result.HasError<NotFoundError>(e => e.Id == 2).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasErrorWithMetadataKey_WithSearchedError()
    {
        var result = Result.Fail(new Error("").WithMetadata("MetadataKey1", "MetadataValue1"));
        result.HasError(e => e.HasMetadataKey("MetadataKey1")).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasErrorWithMetadataValueWithPredicate_WithSearchedError()
    {
        var result = Result.Fail(new Error("").WithMetadata("MetadataKey1", "MetadataValue1"));
        result.HasError(e => e.HasMetadata("MetadataKey1", metadataValue => (string)metadataValue == "MetadataValue1")).Should().BeTrue();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasErrorWithNoMetadataValueWithPredicate_WithSearchedError()
    {
        var result = Result.Fail(new Error(""));
        result.HasError(e => e.HasMetadata("MetadataKey1", metadataValue => (string)metadataValue == "MetadataValue1")).Should().BeFalse();
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void HasSuccess_WithSearchedSuccess()
    {
        var success = new FoundSuccess(3);
        var result = Result.Ok().WithSuccess(success);
        result.HasSuccess<FoundSuccess>(out var successes).Should().BeTrue();
        successes.Should().HaveCount(1).And.Contain(success);
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void HasSuccessWithPredicate_WithSearchedSuccess()
    {
        var result = Result.Ok().WithSuccess(new FoundSuccess(3));
        result.HasSuccess<FoundSuccess>(e => e.Id == 3).Should().BeTrue();
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void HasSuccess_WithoutSearchedSuccess()
    {
        var result = Result.Fail("error");
        result.HasSuccess<FoundSuccess>().Should().BeFalse();
        result.IsSuccess.Should().BeFalse();
    }

    #region Custom

    private class CustomException : Exception
    {
        public CustomException(int id)
            : base("Custom exception")
        {
            Id = id;
        }

        public int Id { get; }
    }

    private record NotFoundError(int Id, string Message, IImmutableDictionary<string, object> Metadata, IImmutableList<IError> Reasons) : Error(Message, Metadata, Reasons)
    {

        public NotFoundError(int id)
            : this(id, "Not Found", ImmutableDictionary<string, object>.Empty, ImmutableList<IError>.Empty)
        {
        }
    }

    private record FoundSuccess(int Id, string Message, IImmutableDictionary<string, object> Metadata) : Success(Message, Metadata)
    {

        public FoundSuccess(int id)
            : this(id, "OK", ImmutableDictionary<string, object>.Empty)
        {
        }
    }

    #endregion

}
