using TurtleMovementSimluatorApp.Enums;
using TurtleMovementSimluatorApp.Interfaces;

namespace TurtleMovementSimluatorApp.Tests
{
    public class TurtleActionSimulatorTests
    {
        ITurtle turtle;
        ITable table;
        Direction direction;
        public TurtleActionSimulatorTests()
        {
            turtle = new Turtle();
            table = new Table(5, 5);
            direction = new Direction();
            direction.CurrentDirection = Directions.NORTH;
        }
        /// <summary>
        /// Test PLACE command with valid input
        /// </summary>
        [Fact]
        public void Place_Test_SUCCESS()
        {
            var actionSimulator = new ActionSimulator(turtle, table);
            actionSimulator.Place(new Position(1, 1), direction);
            Assert.Equal(1, turtle.TurtlePosition.XCoordinate);
            Assert.Equal(1, turtle.TurtlePosition.YCoordinate);
            Assert.Equal(Directions.NORTH, turtle.TurtleDirection.CurrentDirection);
        }

        /// <summary>
        /// Test Move command without Place command
        /// </summary>
        [Fact]
        public void MoveInCurrentDirection_Test_FirstCommand_NoPlace()
        {
            var actionSimulator = new ActionSimulator(turtle, table);
            actionSimulator.MoveInCurrentDirection();
            Assert.Null(turtle.TurtlePosition);
        }

        /// <summary>
        /// Test Move command with Place command
        /// </summary>
        [Fact]
        public void MoveInCurrentDirection_Test()
        {
            var actionSimulator = new ActionSimulator(turtle, table);
            actionSimulator.Place(new Position(1, 1), direction);
            actionSimulator.MoveInCurrentDirection();
            Assert.Equal(1, turtle.TurtlePosition.XCoordinate);
            Assert.Equal(2, turtle.TurtlePosition.YCoordinate);
            Assert.Equal(Directions.NORTH, turtle.TurtleDirection.CurrentDirection);
        }
        /// <summary>
        /// Test ChangeDirection with LEFT direction
        /// </summary>
        [Fact]
        public void ChangeDirection_LEFT_Test()
        {
            var actionSimulator = new ActionSimulator(turtle, table);
            actionSimulator.Place(new Position(1, 1), direction);
            actionSimulator.ChangeDirection(Commands.LEFT);
            Assert.Equal(1, turtle.TurtlePosition.XCoordinate);
            Assert.Equal(1, turtle.TurtlePosition.YCoordinate);
            Assert.Equal(Directions.WEST, turtle.TurtleDirection.CurrentDirection);
        }
        /// <summary>
        ///  Test ChangeDirection with RIGHT direction
        /// </summary>
        [Fact]
        public void ChangeDirection_RIGHT_Test()
        {
            var actionSimulator = new ActionSimulator(turtle, table);
            actionSimulator.Place(new Position(1, 1), direction);
            actionSimulator.ChangeDirection(Commands.RIGHT);
            Assert.Equal(1, turtle.TurtlePosition.XCoordinate);
            Assert.Equal(1, turtle.TurtlePosition.YCoordinate);
            Assert.Equal(Directions.EAST, turtle.TurtleDirection.CurrentDirection);
        }
    }
}