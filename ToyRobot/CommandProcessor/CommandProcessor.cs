using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Data;

namespace ToyRobot
{
    public class CommandProcessor : ICommandProcessor
    {
        // Number of parameters provided for "PLACE" Command. (X,Y,F)
        private const int ParameterCount = 3;

        // Number of raw input items expected from user.
        private const int CommandInputCount = 2;
        /* Validate and return command */
        public CommandLibrary ValidateandReturnCommand(string[] rawInput)
        {
            CommandLibrary command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Please try with allowed format: PLACE X,Y,F MOVE LEFT RIGHT REPORT");
            return command;
        }

        /*Validate and Retun command paramters */
        InputCommandParameter ICommandProcessor.ValidateAndReturnInputCommandParameters(string[] inputParams, IRobot robot)
        {
            Directions direction;
            Position position = null;

            // Checks that Place command is followed by valid command parameters (X,Y and F toy's face direction).
            if (inputParams.Length != CommandInputCount)
                throw new ArgumentException("Invalid PLACE command. use format: PLACE X,Y,F");
            
            // Checks that three command parameters are provided for the PLACE command.   
            var commandParams = inputParams[1].Split(',');
            Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction);
            if (commandParams.Length != ParameterCount || (robot != null && robot.Position != null))
            {
                    direction = robot.Direction;


            }
            // Checks the direction which the toy is going to be facing.
            else if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH EAST SOUTH WEST");
            //else
            //    throw new ArgumentException("Invalid PLACE command. use format: PLACE X,Y,F");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            position = new Position(x, y);

            return new InputCommandParameter(position, direction);
        }
    }

    /* Class to store the command input enteted with the initial Place*/
    public class InputCommandParameter
    {
        public Position Position { get; set; }
        public Directions Direction { get; set; }

        public InputCommandParameter(Position position, Directions direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
