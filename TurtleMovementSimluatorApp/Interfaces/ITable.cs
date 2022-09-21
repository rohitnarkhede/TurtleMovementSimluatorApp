using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementSimluatorApp.Enums;

namespace TurtleMovementSimluatorApp.Interfaces
{
    public interface ITable
    {
        int RowCount { get; }
        int ColumnCount { get; }

        void AddToObsructedList(Position pos);
        bool CheckIfValidMove(Position position);
    }
}
