using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        public Directions Direction { get; set; }
        public Position Position { get; set; }

        /* Get the next position of the Robot after a instruction is issued */
        public Position GetNextPosition()
        {
            var nextPosition = new Position(Position.X, Position.Y);
            switch (Direction)
            {
                case Directions.NORTH:
                    nextPosition.Y = nextPosition.Y + 1;
                    break;
                case Directions.SOUTH:
                    nextPosition.Y = nextPosition.Y - 1;
                    break;
                case Directions.EAST:
                    nextPosition.X = nextPosition.X + 1;
                    break;
;
                case Directions.WEST:
                    nextPosition.X = nextPosition.X - 1;
                    break;
            }
            return nextPosition;
        }

        public void PlaceRobot(Position position, Directions direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public void MoveLeft()
        {

            switch(this.Direction)
            {
                case Directions.NORTH:
                    Direction = Directions.WEST;
                    break;
                case Directions.WEST:
                    Direction = Directions.SOUTH;
                    break;
                case Directions.SOUTH:
                    Direction = Directions.EAST;
                    break;
                case Directions.EAST:
                    Direction = Directions.NORTH;
                    break;
                default:
                    Direction = this.Direction;
                    break;
            }

        }

        public void MoveRight()
        {
            switch (this.Direction)
            {
                case Directions.NORTH:
                    Direction = Directions.EAST;
                    break;
                case Directions.WEST:
                    Direction = Directions.NORTH;
                    break;
                case Directions.SOUTH:
                    Direction = Directions.WEST;
                    break;
                case Directions.EAST:
                    Direction = Directions.SOUTH;
                    break;
                default:
                    Direction = this.Direction;
                    break;
            }
        }
    }
}
