using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementSimluatorApp.Enums;

namespace TurtleMovementSimluatorApp.Interfaces
{
    public interface ITurtle
    {
        Position TurtlePosition { get; set; }
        Direction TurtleDirection { get; set; }
    }
}
