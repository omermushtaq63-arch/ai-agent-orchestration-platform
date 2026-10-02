# Architecture

Request -> agent orchestrator -> planner boundary -> tool registry -> tool execution -> structured result.

The deterministic planner keeps this repository runnable without credentials. Azure OpenAI/Semantic Kernel can be inserted at the planner boundary for production tool/function calling and multi-step workflows.

No proprietary customer implementation is included.