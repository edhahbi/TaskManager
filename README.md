# TaskManager Documentation

## Overview

TaskManager is a command-line task management application built with C# and .NET 10.0. It lets you add, update, and track tasks directly from the terminal with JSON-based data persistence.

## Quick Start

```bash
# Clone and run
git clone https://github.com/edhahbi/TaskManager.git
cd TaskManager
dotnet run add "Your task here"
dotnet run update 0 "Updated description"
dotnet run mark-in-progress 0
dotnet run mark-done 0
```

## Commands

| Command | Description | Usage |
|---------|-------------|-------|
| `add` | Create a new task | `dotnet run add "<description>"` |
| `update` | Modify task description | `dotnet run update <id> "<description>"` |
| `mark-in-progress` | Mark task as in progress | `dotnet run mark-in-progress <id>` |
| `mark-done` | Mark task as completed | `dotnet run mark-done <id>` |

## Task Status

- `0` - Todo (not started)
- `1` - In Progress
- `2` - Done

## Data Storage

Tasks are stored in `db.json` as a JSON array. The file is automatically updated after each command.

## Requirements

- .NET 10.0 SDK
- System.CommandLine (included via NuGet)
