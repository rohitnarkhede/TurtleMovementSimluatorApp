using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementSimluatorApp.Enums;
using TurtleMovementSimluatorApp.Handlers;
using TurtleMovementSimluatorApp.Interfaces;

namespace TurtleMovementSimluatorApp
{
    public class CommandModule
    {
        private readonly IActionSimulator _actionSimulator;

        public CommandModule(IActionSimulator actionSimulator)
        {
            _actionSimulator = actionSimulator;
        }
        public void ExecuteCommands(string cmd)
        {
            Command command = CommandHandler.GetCommands(cmd);

            if (!CheckIfValidCommand(command))
                return;

            switch (command.NextCommand)
            {
                case Commands.REPORT:
                    _actionSimulator.Report();
                    break;
                case Commands.LEFT:
                    _actionSimulator.ChangeDirection(command.NextCommand);
                    break;
                case Commands.RIGHT:
                    _actionSimulator.ChangeDirection(command.NextCommand);
                    break;
                case Commands.PLACE:
                    _actionSimulator.Place(command.NextPosition, command.Direction);
                    break;
                case Commands.MOVE:
                    _actionSimulator.MoveInCurrentDirection();
                    break;
               
                default:
                    break;
            }

        }
       
        public bool CheckIfValidCommand(Command cmd)
        {
            if (!Enum.IsDefined(typeof(Commands), cmd.NextCommand))
                return false;
            if (!cmd.NextCommand.Equals(Commands.PLACE) && !_actionSimulator.IfPlaceCommandEntered())
                return false;
            if (cmd.NextCommand.Equals(Commands.PLACE) && cmd.NextPosition == null)
                return false;
            if (cmd.Direction != null && !Enum.IsDefined(typeof(Directions), cmd.Direction.CurrentDirection))
                return false;
            return true;
        }
    }
}
