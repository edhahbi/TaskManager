using System.CommandLine;

namespace TaskManager.Commands;

public class TaskCli
{
    public static RootCommand rootCommand = new RootCommand();

    public static void initCommands()
    {
        var descriptionArg = new Argument<string>("description");
        var idArg = new Argument<int>("id");
        var statusArg = new Argument<string>("status");
        
        var addCommand = new Command("add", "adds a task");
        var updateDescriptionCommand = new Command("update", "updates a command by id");
        var markInProgessCommand = new Command("mark-in-progress", "makes a task to be in progress by id");
        var markDoneCommand = new Command("mark-done", "mark a task to be done");
        
        initAddCommand(addCommand,descriptionArg);
        initUpdateDescriptionCommand(updateDescriptionCommand,descriptionArg, idArg);
        initMarktatusCommand(markInProgessCommand,idArg,Status.in_progress);
        initMarktatusCommand(markDoneCommand,idArg,Status.done);
        
        rootCommand.Add(addCommand);
        rootCommand.Add(updateDescriptionCommand);
        rootCommand.Add(markInProgessCommand);
        rootCommand.Add(markDoneCommand);
    }

    public static void invoke(string[] args)
    {
        rootCommand.Parse(args).Invoke();
    }

    static void initAddCommand(Command addCommand, Argument<string> descriptionArg )
    {
        addCommand.Add(descriptionArg);
        addCommand.SetAction(ctx =>
        {
            string? description = ctx.GetValue<string>(descriptionArg);
            if (description != null)
            {
                TaskManager.Create(description);
            }
            else
            {
                Console.WriteLine("wrong descreption argument for addCommand");
            }
        });
    }

    static void initUpdateDescriptionCommand(Command updateCommand, Argument<string> descriptionArg, Argument<int> idArg)
    {
        updateCommand.Add(idArg);
        updateCommand.Add(descriptionArg);
        updateCommand.SetAction(ctx =>
        {
            string? description = ctx.GetValue<string>(descriptionArg);
            int? id = ctx.GetValue<int>(idArg);

            if (id != null && description != null)
            {
                TaskManager.UpdateDescription(id.Value, description);
            }
            else
            {
                Console.WriteLine("wrong id or desciption argument for the update command");
            }
        });

    }

    static void initMarktatusCommand(Command updateCommand, Argument<int> idArg, Status status)
    {
        updateCommand.Add(idArg);
        updateCommand.SetAction(ctx =>
        {
            int? id = ctx.GetValue<int>(idArg);
            if (id != null)
            {
                TaskManager.UpdateStatus(id.Value, status);
            }
            else
            {
                Console.WriteLine($"wrong id or status argument for {updateCommand.Name} command");
            }
        });
    }
}