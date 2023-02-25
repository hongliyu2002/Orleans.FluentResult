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
    }

    [Fact]
    public void HasExceptionWithPredicate_WithRootError()
    {
        var error = new ExceptionalError(new CustomException(1));
        var result = Result.Fail(error);
        result.HasException<CustomException>(ex => ex.Id == 1).Should().BeTrue();
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
    }

    [Fact]
    public void HasException_WithSearchedError()
    {
        var result = Result.Fail(new NotFoundError(3).CausedBy(new CustomException(1)));
        result.HasException<CustomException>().Should().BeTrue();
    }

    [Fact]
    public void HasExceptionWithPredicate_WithSearchedError()
    {
        var result = Result.Fail(new NotFoundError(3).CausedBy(new CustomException(1)));
        result.HasException<CustomException>(e => e.Id == 1).Should().BeTrue();
    }

    [Fact]
    public void HasException_WithoutSearchedError()
    {
        var result = Result.Ok();
        result.HasException<CustomException>().Should().BeFalse();
    }

    [Fact]
    public void HasExceptionInNestedError_WithoutSearchedError()
    {
        var result = Result.Ok().WithError(new Error("Main Error").CausedBy(new CustomException(1)));
        result.HasException<CustomException>().Should().BeTrue();
    }

    private class CustomException : Exception
    {
        public CustomException(int id)
            : base("Custom exception")
        {
            Id = id;
        }

        public int Id { get; }
    }

    private class NotFoundError : Error
    {

        public NotFoundError(int id)
            : base("Not Found")
        {
            Id = id;
        }

        public int Id { get; }
    }

    private class FoundSuccess : Success
    {

        public FoundSuccess(int id)
            : base("")
        {
            Id = id;
        }

        public int Id { get; }
    }
}
