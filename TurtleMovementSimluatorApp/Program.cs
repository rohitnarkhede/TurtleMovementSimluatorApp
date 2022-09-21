using TurtleMovementSimluatorApp.Interfaces;

namespace TurtleMovementSimluatorApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITable table = new Table(5, 5);
            ITurtle turtle = new Turtle();
            IActionSimulator re = new ActionSimulator(turtle, table);
            CommandModule cmd = new CommandModule(re);

            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please specify a .txt filepath.");
                return;
            }
            if (File.Exists(args[0]) && (Path.GetExtension(args[0]) == ".txt"))
            {
                string[] commands = File.ReadAllLines(args[0]);
                foreach (string command in commands)
                {
                    cmd.ExecuteCommands(command);

                }
            }
            else 
            {
                bool exit = false;
                Console.WriteLine($"Press E+Enter to exit. Refer Readme.md file and enter Input Commands");
                while (!exit)
                {
                    var command = Console.ReadLine();
                    if (command == "E")
                        exit = true;
                    else
                        cmd.ExecuteCommands(command);
                }
                
            }

        }
    }
}