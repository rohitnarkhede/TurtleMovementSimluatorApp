using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementSimluatorApp.Enums;
using TurtleMovementSimluatorApp.Interfaces;

namespace TurtleMovementSimluatorApp
{
    public class ActionSimulator : IActionSimulator
    {
        private readonly ITurtle _turtle;
        private readonly ITable _table;
        public ActionSimulator(ITurtle Turtle, ITable table)
        {
            _turtle = Turtle;
            _table = table;
        }
      
        public void MoveInCurrentDirection()
        {
            if (_turtle.TurtlePosition == null)
                return;
            Position newPosition = new Position(_turtle.TurtlePosition.XCoordinate, _turtle.TurtlePosition.YCoordinate);
            switch (_turtle.TurtleDirection.CurrentDirection)
            {
                case Directions.EAST:
                    newPosition.XCoordinate += 1;
                    break;
                case Directions.WEST:
                    newPosition.XCoordinate -= 1;
                    break;
                case Directions.NORTH:
                    newPosition.YCoordinate += 1;
                    break;
                case Directions.SOUTH:
                    newPosition.YCoordinate -= 1;
                    break;               

            }
            if (_table.CheckIfValidMove(newPosition))
                _turtle.TurtlePosition = newPosition;
        }

       
        public void Place(Position position, Direction direction)
        {

            if (!_table.CheckIfValidMove(position))
                return;
            if (_turtle.TurtlePosition == null && direction == null)
                return;
            if (position != null)
                _turtle.TurtlePosition = position;

            if (direction != null)
                _turtle.TurtleDirection = direction;
        }

        
        public void ChangeDirection(Commands dirCommand)
        {
            switch (dirCommand)
            {
                case Commands.LEFT:
                    if ((int)_turtle.TurtleDirection.CurrentDirection - 1 < 0)
                        _turtle.TurtleDirection.CurrentDirection = (Directions)Enum.GetValues(typeof(Directions)).Length - 1;
                    else
                        _turtle.TurtleDirection.CurrentDirection = (Directions)((int)_turtle.TurtleDirection.CurrentDirection - 1);
                    break;
                case Commands.RIGHT:
                    if ((int)_turtle.TurtleDirection.CurrentDirection + 1 == Enum.GetValues(typeof(Directions)).Length)
                        _turtle.TurtleDirection.CurrentDirection = (Directions)(((int)_turtle.TurtleDirection.CurrentDirection + 1) % Enum.GetValues(typeof(Directions)).Length);
                    else
                        _turtle.TurtleDirection.CurrentDirection = (Directions)((int)_turtle.TurtleDirection.CurrentDirection + 1);
                    break;
                default:
                    break;
            }
        }

      
        public void Report()
        {
            Console.WriteLine($"{_turtle.TurtlePosition.XCoordinate},{_turtle.TurtlePosition.YCoordinate},{_turtle.TurtleDirection.CurrentDirection}");
        }       

       
        public bool IfPlaceCommandEntered()
        {
            return _turtle.TurtlePosition != null;
        }
    }
}
