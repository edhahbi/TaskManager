using System.CommandLine;
using TM = TaskManager;

class Program
{
    static void Main(string[] args)
    {
        TM.Commands.TaskCli.initCommands();
        while (true)
        {
            TM.Commands.TaskCli.invoke(args);
        }
    }
}