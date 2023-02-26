using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class ErrorStringifyTests
{
    [Fact]
    public void EmptyErrorToString_OnlyType()
    {
        var error = new Error("");
        error.ToString()
             .Should()
             .Be("Error");
    }

    [Fact]
    public void ErrorWithReasonsToString_TypeWithReasons()
    {
        var error = new Error("").CausedBy("My first cause")
                                 .CausedBy("My second cause");
        error.ToString()
             .Should()
             .Be("Error with Reasons='Error with Message='My first cause'; Error with Message='My second cause''");
    }
}
