namespace AgentPlatform;

public interface IAgentTool
{
    string Name { get; }
    Task<string> ExecuteAsync(string input);
}

public sealed class CalculatorTool : IAgentTool
{
    public string Name => "calculator";
    public Task<string> ExecuteAsync(string input)
    {
        try { return Task.FromResult(input.Split('+', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Sum().ToString("0.##")); }
        catch { return Task.FromResult("Unable to evaluate expression."); }
    }
}

public sealed class TimeTool : IAgentTool
{
    public string Name => "time";
    public Task<string> ExecuteAsync(string input) => Task.FromResult(DateTimeOffset.UtcNow.ToString("O"));
}

public sealed class ToolRegistry
{
    public IReadOnlyList<IAgentTool> Tools { get; } = new IAgentTool[] { new CalculatorTool(), new TimeTool() };
    public IAgentTool? Find(string name) => Tools.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}