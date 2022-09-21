using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementSimluatorApp.Interfaces;

namespace TurtleMovementSimluatorApp
{
    public class Turtle : ITurtle
    {
        public Position TurtlePosition { get; set; }
        public Direction TurtleDirection { get; set; }
    }
}
