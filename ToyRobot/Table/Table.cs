using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    /// <summary>
    /// Table class implemeting ITable interface to validate the Robot movemtn 
    /// is within the able dimention
    /// </summary>
    public class Table : ITable
    {
        public int _rows { get; private set; }
        public int _columns { get; private set; }

        public Table(int rows, int columns)
        {
            this._rows = rows;
            this._columns = columns;
        }

        // Validate the position on the table
        public bool IsValidTablePosition(Position position)
        {
            return position.X < _columns && position.X >= 0 &&
                   position.Y < _rows && position.Y >= 0;
        }
    }
}
