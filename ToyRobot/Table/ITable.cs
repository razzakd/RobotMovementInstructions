using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public interface ITable
    {
        bool IsValidTablePosition(Position position);
    }
}
