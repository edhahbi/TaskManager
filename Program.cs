using System.CommandLine;
using TM = TaskManager;

class Program
{
    static void Main(string[] args)
    {
        TM.Commands.TaskCli.initCommands(); 
        TM.TaskManager.LoadJson();
        TM.Commands.TaskCli.invoke(args);
        TM.TaskManager.PrintTasks(); 
        TM.TaskManager.SaveJson();
    }
}