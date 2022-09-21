using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementSimluatorApp.Enums;

namespace TurtleMovementSimluatorApp.Interfaces
{
    public interface IActionSimulator
    {
        void Place(Position position, Direction direction);
        void MoveInCurrentDirection();
        void ChangeDirection(Commands dirCommand);
        void Report();//test
        public bool IfPlaceCommandEntered();
      
    }
}
