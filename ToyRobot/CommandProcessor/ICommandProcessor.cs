using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Data;

namespace ToyRobot
{
    public interface ICommandProcessor
    {
        /* Matches the command input with the valid list of commands */
        CommandLibrary ValidateandReturnCommand(string[] rawInput);


        InputCommandParameter ValidateAndReturnInputCommandParameters(string[] inputParams);
    }
}
