using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            ITable board = new Table(5, 5);
            ICommandProcessor inputCommandProcessor = new CommandProcessor();
            IRobot robot = new Robot();
            var instruction = new Instruction(robot, board, inputCommandProcessor);
            var terminateApp = false;
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    terminateApp = true;
                else
                {
                    try
                    {
                        var output = instruction.processInstruction(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!terminateApp);
        }
    }
}
