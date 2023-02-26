using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class SuccessTests
{

    [Fact]
    public void CreateSuccess_EmptySuccess()
    {
        var success = new Success("My success message");
        success.Message.Should().Be("My success message");
        success.Metadata.Should().BeEmpty();
    }

    [Fact]
    public void CreateCustomSuccessWithNoMessage_CustomSuccessWithMessage()
    {
        var success = new CustomSuccess();
        success.Message.Should().BeEmpty();
        success.Metadata.Keys.Should().BeEmpty();
    }

    public record CustomSuccess : Success
    {
    }
}
