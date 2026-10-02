using AgentPlatform;

var b = WebApplication.CreateBuilder(args);
b.Services.AddSingleton<ToolRegistry>();
b.Services.AddSingleton<AgentOrchestrator>();
b.Services.AddEndpointsApiExplorer();
b.Services.AddSwaggerGen();

var app = b.Build();
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }

app.MapGet("/health", () => new { status = "healthy", service = "agent-orchestration" });
app.MapPost("/api/agent/run", async (AgentRequest req, AgentOrchestrator o) =>
    Results.Ok(await o.RunAsync(req)));

app.Run();
public record AgentRequest(string Task);