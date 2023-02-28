using System.Collections.Immutable;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Orleans.FluentResults.Test.Mocks;
using Xunit;

namespace Orleans.FluentResults.Test;

public class ResultLoggingTests
{
    [Fact]
    public void LogOkResult_EmptySuccess()
    {
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log();
        logger.LoggedContext.Should().Be(string.Empty);
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Information);
    }

    [Fact]
    public void LogOkResultWithContext_EmptySuccess()
    {
        var context = "context";
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log(context);
        logger.LoggedContext.Should().Be(context);
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Information);
    }

    [Fact]
    public void LogOkResultWithTypedContext_EmptySuccess()
    {
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log<Result>();
        logger.LoggedContext.Should().Be(typeof(Result).ToString());
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Information);
    }

    [Fact]
    public void LogOkResultWithContent_EmptySuccess()
    {
        var context = "context";
        var content = "content";
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log(context, content);
        logger.LoggedContext.Should().Be(context);
        logger.LoggedContent.Should().Be(content);
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Information);
    }

    [Fact]
    public void LogOkResultWithContentAndTypedContext_EmptySuccess()
    {
        var content = "content";
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log<Result>(content);
        logger.LoggedContext.Should().Be(typeof(Result).ToString());
        logger.LoggedContent.Should().Be(content);
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Information);
    }

    [Fact]
    public void LogOkResultLevel_EmptySuccess()
    {
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log(LogLevel.Critical);
        logger.LoggedContext.Should().BeNullOrEmpty();
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Critical);
    }

    [Fact]
    public void LogOkResultWithContextAndLevel_EmptySuccess()
    {
        var context = "context";
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log(context, LogLevel.Critical);
        logger.LoggedContext.Should().Be(context);
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Critical);
    }

    [Fact]
    public void LogOkResultWithTypedContextAndLevel_EmptySuccess()
    {
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log<Result>(LogLevel.Critical);
        logger.LoggedContext.Should().Be(typeof(Result).ToString());
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Critical);
    }

    [Fact]
    public void LogOkResultWithContentAndLevel_EmptySuccess()
    {
        var context = "context";
        var content = "content";
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log(context, content, LogLevel.Critical);
        logger.LoggedContext.Should().Be(context);
        logger.LoggedContent.Should().Be(content);
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Critical);
    }

    [Fact]
    public void LogOkResultWithContentAndTypedContextAndLevel_EmptySuccess()
    {
        var content = "content";
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().Log<Result>(content, LogLevel.Critical);
        logger.LoggedContext.Should().Be(typeof(Result).ToString());
        logger.LoggedContent.Should().Be(content);
        logger.LoggedResult.Should().NotBeNull();
        logger.LoggedLevel.Should().Be(LogLevel.Critical);
    }

    [Fact]
    public void OkResultLogWhenSuccess_EmptySuccess()
    {
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().LogIfSuccess();
        logger.LoggedContext.Should().BeNullOrEmpty();
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
    }

    [Fact]
    public void FailedResultLogWhenFailed_Empty()
    {
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Fail("").LogIfFailed();
        logger.LoggedContext.Should().BeNullOrEmpty();
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().NotBeNull();
    }

    [Fact]
    public void FailedResultLogWhenSuccess_EmptySuccess()
    {
        var logger = new LoggingMock();
        Result.Fail("").LogIfSuccess();
        logger.LoggedContext.Should().BeNullOrEmpty();
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().BeNull();
    }

    [Fact]
    public void OkResultLogWhenFailed_Empty()
    {
        var logger = new LoggingMock();
        ResultSettings.Setup(builder => { builder.Logger = logger; });
        Result.Ok().LogIfFailed();
        logger.LoggedContext.Should().BeNullOrEmpty();
        logger.LoggedContent.Should().BeNullOrEmpty();
        logger.LoggedResult.Should().BeNull();
    }

    [Fact]
    public void FailedResult_MapErrors()
    {
        var result = Result.Fail("Failure 1").WithSuccess("Success 1");
        result = result.MapError(e => new CustomError("Prefix: " + e.Message));
        result.Should().BeOfType<Result>();
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Message.Should().Be("Prefix: Failure 1");
        result.Successes.Should().HaveCount(1);
        result.Successes[0].Message.Should().Be("Success 1");
    }

    [Fact]
    public void FailedValueResult_MapErrors()
    {
        var result = Result<int>.Fail("Failure 1").WithSuccess("Success 1");
        result = result.MapError(e => new CustomError("Prefix: " + e.Message));
        result.Should().BeOfType<Result<int>>();
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Message.Should().Be("Prefix: Failure 1");
        result.Successes.Should().HaveCount(1);
        result.Successes[0].Message.Should().Be("Success 1");
    }

    [Fact]
    public void SuccessValueResult_MapSuccesses()
    {
        var result = Result<int>.Ok(5).WithSuccess("Success 1");
        result = result.MapSuccess(e => new Success("Prefix: " + e.Message));
        result.Should().BeOfType<Result<int>>();
        result.Successes.Should().HaveCount(1);
        result.Successes[0].Message.Should().Be("Prefix: Success 1");
        result.Errors.Should().BeEmpty();
        result.Value.Should().Be(5);
    }

    [Fact]
    public void SuccessResult_MapSuccesses()
    {
        var result = Result.Ok().WithSuccess("Success 1");
        result = result.MapSuccess(e => new Success("Prefix: " + e.Message));
        result.Should().BeOfType<Result>();
        result.Successes.Should().HaveCount(1);
        result.Successes[0].Message.Should().Be("Prefix: Success 1");
        result.Errors.Should().BeEmpty();
    }

    #region Custom

    private record CustomError(string Message, IImmutableDictionary<string, object> Metadata, IImmutableList<IError> Reasons) : Error(Message, Metadata, Reasons)
    {
        public CustomError(string message)
            : this(message, ImmutableDictionary<string, object>.Empty, ImmutableList<IError>.Empty)
        {
        }
    }

    #endregion

}
