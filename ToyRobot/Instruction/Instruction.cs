using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Data;
using ToyRobot;

namespace ToyRobot
{
    public class Instruction
    {
        public IRobot _mRobot { get; private set; }
        public ITable _mBoard { get; private set; }
        public ICommandProcessor _mCommandPorcessor { get; private set; }

        public Instruction(IRobot robot, ITable board, ICommandProcessor cmdProcessor)
        {
            _mRobot = robot;
            _mBoard = board;
            _mCommandPorcessor = cmdProcessor;
        }

        public string processInstruction(string[] input)
        {
            var instruction = _mCommandPorcessor.ValidateandReturnCommand(input);
            if (instruction != CommandLibrary.Place && _mRobot.Position == null) return string.Empty;

            switch (instruction)
            {
                case CommandLibrary.Place:
                    var placeCommandParameter = _mCommandPorcessor.ValidateAndReturnInputCommandParameters(input, _mRobot);
                    if (_mBoard.IsValidTablePosition(placeCommandParameter.Position))
                    {
                        _mRobot.PlaceRobot(placeCommandParameter.Position, placeCommandParameter.Direction);
                    }
                    break;
                case CommandLibrary.Move:
                    var newPosition = _mRobot.GetNextPosition();
                    if (_mBoard.IsValidTablePosition(newPosition))
                        _mRobot.Position = newPosition;
                    break;
                case CommandLibrary.Left:
                    _mRobot.MoveLeft();
                    break;
                case CommandLibrary.Right:
                    _mRobot.MoveRight();
                    break;
                case CommandLibrary.Report:
                    return GenerateReport();
            }
            return string.Empty;
        }

        public string GenerateReport()
        {
            return $"Output: {_mRobot.Position.X},{_mRobot.Position.Y},{_mRobot.Direction.ToString().ToUpper()}";
        }
    }
}
