using FluentAssertions;
using Xunit;

namespace Orleans.FluentResults.Test;

public class MergeTests
{
    [Fact]
    public void Merge_WithResultWithoutValue_ShouldMergeResults()
    {
        var results = new List<Result>
                      {
                          Result.Ok(),
                          Result.Fail("Fail 1")
                      };
        var mergedResult = results.Merge();
        mergedResult.IsFailed.Should().BeTrue();
        mergedResult.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Merge_WithFailedResultWithValue_ShouldMergeResults()
    {
        var results = new List<Result<int>>
                      {
                          Result<int>.Ok(12),
                          Result<int>.Fail("Fail 1")
                      };
        var mergedResult = results.Merge();
        mergedResult.IsFailed.Should().BeTrue();
        mergedResult.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Merge_WithSuccessResultWithValue_ShouldMergeResults()
    {
        var results = new List<Result<int>>
                      {
                          Result<int>.Ok(1),
                          Result<int>.Ok(2)
                      };
        var mergedResult = results.Merge();
        mergedResult.IsSuccess.Should().BeTrue();
        mergedResult.Value.Should().HaveCount(2);
        mergedResult.Value.Should()
       .BeEquivalentTo(new[]
                       {
                           1,
                           2
                       });
    }
}
