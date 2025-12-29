using System.CommandLine;

namespace TaskManager.Commands;

public class TaskCli
{
    public static RootCommand rootCommand = new RootCommand();

    public static void initCommands()
    {
        var descriptionArg = new Argument<string>("description");
        var idArg = new Argument<int>("id");
        var status = new Argument<string>("status");
        
        var addCommand = new Command("add", "adds a task");
        initAddCommand(addCommand,descriptionArg);
        rootCommand.Add(addCommand);
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
                Console.WriteLine("wrong descreption argument");
            }
        });
    }
    

}