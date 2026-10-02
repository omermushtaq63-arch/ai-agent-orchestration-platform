namespace AgentPlatform;

public sealed class AgentOrchestrator
{
    private readonly ToolRegistry _tools;
    public AgentOrchestrator(ToolRegistry tools) => _tools = tools;

    public async Task<object> RunAsync(AgentRequest req)
    {
        var task = req.Task.Trim();
        if (task.StartsWith("calculate:", StringComparison.OrdinalIgnoreCase))
        {
            var tool = _tools.Find("calculator")!;
            return new { mode = "tool", tool = tool.Name, result = await tool.ExecuteAsync(task[10..].Trim()) };
        }

        if (task.Equals("time", StringComparison.OrdinalIgnoreCase))
        {
            var tool = _tools.Find("time")!;
            return new { mode = "tool", tool = tool.Name, result = await tool.ExecuteAsync(task) };
        }

        return new { mode = "orchestration", message = "No deterministic tool matched; connect an LLM planner here for production tool/function calling.", task };
    }
}