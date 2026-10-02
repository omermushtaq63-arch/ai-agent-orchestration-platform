using Xunit;
using AgentPlatform;

public class AgentTests
{
    [Fact]
    public async Task CalculatorToolWorks()
    {
        var result = await new CalculatorTool().ExecuteAsync("2+3+5");
        Assert.Equal("10", result);
    }
}