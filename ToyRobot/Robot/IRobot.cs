using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public interface IRobot
    {
        Directions Direction { get; set; }
        Position Position { get; set; }

 
        /// <summary>
        /// Set the position and direction of the Robot on the Table 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        void PlaceRobot(Position position, Directions direction);

        /// <summary>
        ///Verify the poistion of the robot based on the current placement insturctions. This is to avoid any fatal movement  
        /// </summary>
        /// <returns></returns>
        Position GetNextPosition();


        /// <summary>
        /// Move the Robot to the left by an angle of 90 egrees.
        /// </summary>

        void MoveLeft();

        /// <summary>
        /// Move the robot to the right by an angle of 90 egrees.
        /// </summary>

        void MoveRight();
   
    }
}
