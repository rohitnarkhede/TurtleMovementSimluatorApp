using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementSimluatorApp.Enums;

namespace TurtleMovementSimluatorApp
{
    public class Command
    {
        public Position NextPosition { get; set; }
        public Commands NextCommand { get; set; }
        public Direction Direction { get; set; }
    }
}
