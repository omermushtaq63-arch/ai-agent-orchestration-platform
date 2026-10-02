# AI Agent Orchestration Platform

A .NET 8 service demonstrating agent routing, tool registration, deterministic tool execution, and an extensible orchestration boundary for LLM-based agents.

> Portfolio implementation based on professional experience and documented technology areas. No proprietary code or customer data is included.

## Stack
C# / .NET 8 / ASP.NET Core / tool calling / agent orchestration / Semantic Kernel-ready architecture / REST API

## Run
```bash
dotnet restore
dotnet run --project src
```

## API
- `GET /health`
- `POST /api/agent/run` with `{"task":"calculate: 2+3+5"}`
- `POST /api/agent/run` with `{"task":"time"}`

The deterministic planner keeps the project runnable without cloud credentials. An Azure OpenAI/Semantic Kernel planner can be inserted at the orchestration boundary.

License: MIT.