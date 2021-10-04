using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    /// <summary>
    /// Class to store the poistion of the Robot 
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
